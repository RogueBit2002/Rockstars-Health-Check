DROP USER IF EXISTS 'rhc-admin'@'localhost';

CREATE USER 'rhc-admin'@'localhost' IDENTIFIED WITH mysql_native_password BY 'r00t';

GRANT ALL PRIVILEGES ON `rockstars_health_check`.* TO 'rhc-admin'@'localhost';