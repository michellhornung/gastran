#!/bin/bash
# Aguarde o SQL Server estar pronto
echo "Waiting for SQL Server to be available..."
sleep 30

echo "Restoring database from dump..."
/opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "YourComplexPassword123!" -C -i /docker-entrypoint-initdb.d/init.sql

# Manter o SQL Server em execução
exec /opt/mssql/bin/sqlservr
