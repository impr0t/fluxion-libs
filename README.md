# FluxionLibs 
*Application support libraries for C# + Mono Framework.  Leverages GTK# for user interfaces.*

## Implementation
*Initial implementation of both a logging component and database component.*

The database components are capable of consuming a class marked with custom attributes and creating a database table with it. They are also used for writing / reading data from various data sources.  Only Sqlite is supported at this time.

The Xlog logging components provide coded log records which can then be read using the Log Viewer.  The log viewer will decode the log data and provide color coding to log entries.

## Usage
### Object first database creation and query management.

See `Ca.Fluxion.LogView.IO.SettingsManager`
This class is the concrete implementation of a manager class used for reading and writing settings to a data source.

The SettingsManager inherits from `Ca.Fluxion.Managers.Data.BaseManager<T>` where T is the data model used for initialization procedures.  Moving into the BaseManager constructor will show how the underlying connection logic is being used.  Currently, a connection pool is kept and will allow for reusage of a specific connection if input connection string matches that of an existing connection.

Connections are implemented through the usage of the `IDataBus` interface.  Currently only a `SqliteDataBus` exists and implements this interface, but considerations for and `XmlDataBus` are on the table.  More research into XML databases needs to be done before any further work will continue.

If our currently provided connection type is of Sqlite, we will first try to resolve a connection from the connection pool.  If a connection cannot be resolved a new one will be created and added to the connection pool for future use.  After the connection has been created, we then move into our initialization procedures.  `BaseManager<T>.Init(Type T)` makes a call to the underlying current IDataBus to signal a initialization procedure to begin.  Since only the Sqlite databus implementation exists at this time, we will move into the initialization procedures therein.

`Ca.Fluxion.Transports.Data.SqliteDataBus` has an initialization procedure that leverages usage of the `Ca.Fluxion.Transports.Data.SqliteDataInitializer` class.  This class is inherits from `Ca.Fluxion.Transports.Data.BaseDataInitializer` and is responsible for both validating the currently type object provided to the aforementioned SettingsManager.  The Validation procedure iterates through all publicly exposed properties of the provided type, and looks for custom attributes which are outlined in the `Ca.Fluxion.Managers.Data.Models.Attributes` classes.  These custom attributes are what dictate specifics about how to create the persistant datastore.  Once this validation has passed, we move on to the Process function which then again iterates through the given data type and generates structured queries for the SqliteDataBus to execute.

After the peristant store has been created, our `SettingsManager` will now have access.  The current implementation of the settings manager is rough to say the least, but it provids at least a small view of some of the functionality that can be achieved through this current method.

## USAGE
### Logging components.

See `Ca.Fluxion.Logging.XLog`
The XLog component is used for simplified logging, and provided facilities for using both a textfile or a database for logging information.  The XLog constructors take either a directory and file for writing, or a `Ca.Fluxion.Logging.XLogDB` object.

XLogDB provides facilities for initializing a database and creating a logging table it also provided facilities for writing log entries to the new table.  For simple usage, see `sandbox.dbSandbox`.
