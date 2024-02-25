echo Executando 01-CriarUsuario.sql
/opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P SqlServer2019! -d master -i /tmp/01-CriarUsuario.sql

echo Executando 02-CriarNovaBase.sql
/opt/mssql-tools/bin/sqlcmd -S sqlserver -U user_github -P UserSqlServer2019! -d master -i /tmp/02-CriarNovaBase.sql

echo Executando 03-CriandoTabelas.sql
/opt/mssql-tools/bin/sqlcmd -S sqlserver -U user_github -P UserSqlServer2019! -d master -i /tmp/03-CriandoTabelas.sql
