
IF EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'user_github')
BEGIN
    PRINT 'O usuario user_github ja existe.';
END
ELSE
BEGIN
    PRINT 'O usuario user_github nao existe. Criando...';

    CREATE LOGIN [user_github] WITH PASSWORD=N'UserSqlServer2019!', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF

    ALTER LOGIN [user_github] WITH DEFAULT_LANGUAGE = Portuguese

    ALTER LOGIN [user_github] ENABLE

    ALTER SERVER ROLE [sysadmin] ADD MEMBER [user_github]

END
