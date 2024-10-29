# .NET Clean Architecture vs. N-Tier Project

Bu proje, .NET ile geliştirilmiş Clean Architecture ve N-Tier mimarilerinin farklarını gözlemlemek amacıyla hazırlanmıştır. **MSSQL** veritabanı kullanılarak çalıştırılabilir.

## Gereksinimler

1. **MSSQL**: Proje, bir SQL Server veritabanına ihtiyaç duymaktadır. Docker ile MSSQL'i hızlıca başlatabilirsiniz.
2. **.NET SDK**: Projeyi geliştirmek veya çalıştırmak için .NET SDK'nın yüklü olduğundan emin olun.

## Başlangıç Adımları

1. Projeyi klonlayın:
   ```bash
   git clone https://github.com/yigitcanolmez/NetCore-ApiBestPractice
   cd NetCore-ApiBestPractice
   ```
2. MSSQL Docker konteynerini çalıştırın:
  ```bash
  docker pull mcr.microsoft.com/azure-sql-edge
  docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=Password12*" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge
  ```
3. Projeyi başlatın:
   - Veritabanına bağlanmak için gerekli bağlantı dizesini ayarlayın. Aşağıdaki gibi bir bağlantı dizesi kullanabilirsiniz:
     ```
     "Server=localhost;Database=YourDatabaseName;User Id=SA;Password=Password12*;"
     ```
   - Projeyi çalıştırmak için aşağıdaki komutu kullanın:
   ```bash
   dotnet run
   ```
   Proje başladığı anda sağlamış olduğunuz veritabanı özelinde migration gerçekleşecektir.

Şuanda master branch'inde N-Tier özelinde bir çalışma yapılmaktadır.

