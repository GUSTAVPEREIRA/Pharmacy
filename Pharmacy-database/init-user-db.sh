#!/bin/bash

set -e

psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" <<-EOSQL
    CREATE USER pharmacydbuser;
    CREATE DATABASE pharmacydb;
    GRANT ALL PRIVILEGES ON DATABASE pharmacydb TO pharmacydbuser;
EOSQL