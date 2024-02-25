
IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'OPERADORA_TESTE')
BEGIN
    PRINT 'O banco de dados OPERADORA_TESTE ja existe. Nao sera necessario restaurar OPERADORA_NOVA.BAK';
END
ELSE
BEGIN
    PRINT 'O banco de dados OPERADORA_TESTE nao existe. Criando...'

    CREATE DATABASE OPERADORA_TESTE ON ( NAME = Operadora, FILENAME = '/tmp/Operadora.mdf' )
    LOG ON ( NAME = OperadoraLog, FILENAME = '/tmp/Operadora.ldf' );
END
