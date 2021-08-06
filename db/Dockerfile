FROM mysql:8.0.25
EXPOSE 3306
COPY ./RestWithASPNET/db/migrations/ /home/database/
COPY ./RestWithASPNET/db/dataset/ /home/database/
COPY ./RestWithASPNET/ci/init_database.sh/ /docker-entrypoint-initdb.d/init_database.sh