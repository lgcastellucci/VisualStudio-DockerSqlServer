
IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'OPERADORA_TESTE')
BEGIN
    PRINT 'O banco de dados OPERADORA_TESTE ja existe. Configurando...';

    USE OPERADORA_TESTE

    IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'ACESSOS')
    BEGIN
       CREATE TABLE ACESSOS
	   (
		   ID INT PRIMARY KEY IDENTITY(1,1),
           DATA DATE,
		   ENDPOINT VARCHAR(100),
		   REQUEST VARCHAR(100),
           RESPONSE VARCHAR(100)
	   )
        
    END

END
ELSE
BEGIN
    PRINT 'O banco de dados OPERADORA_TESTE nao existe.'
END

