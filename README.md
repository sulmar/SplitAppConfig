# SplitAppConfig
Aplikacja demonstruje w jaki sposób można podzielić plik konfiguracyjny aplikacji App.config na kilka plików konfiguracyjnych.
Takie podejście ułatwia utworzenie instalatora, który tylko częściowo powinien modyfikować ustawienia aplikacji.


## Connection String

W głównym pliku konfiguracyjnym aplikacji App.config umieszczamy tylko odwołanie do zewnętrznego pliku konfiguracyjnego:

~~~ xml
 <connectionStrings configSource="connectionStrings.config" />
~~~
 
Następnie przenosimy parametry połączenia z bazą danych do nowego pliku connectionStrings.config
 
~~~ xml
<?xml version="1.0" encoding="utf-8" ?>
<connectionStrings>
  <add name="MyConnection" providerName="System.Data.SqlClient" connectionString="Data Source=(local)\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" />
</connectionStrings>
~~~

W kodzie aplikacji możemy pobrać parametr połączenia do bazy danych w standardowy następujący sposób:

~~~ csharp
 var connection = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;               
~~~

Należy pamiętać o dodaniu biblioteki System.Configuration




## Ustawienia aplikacji

W podobny sposób możemy postąpić z ustawieniami aplikacji:

~~~ xml
 <appSettings configSource="settings.config" />
 ~~~
 
 i tworzymy plik settings.config
 
 ~~~ xml
 <?xml version="1.0" encoding="utf-8" ?>
  <appSettings>
    <add key="ServiceUrl" value="http://127.0.0.1:5005" />
  </appSettings>
  ~~~

 W kodzie aplikacji możemy pobrać parametr w następujący sposób:

~~~ csharp
var serviceUrl = ConfigurationManager.AppSettings["ServiceUrl"];
~~~

 
 
