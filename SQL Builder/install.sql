DROP DATABASE IF EXISTS `rockstars_health_check`;

CREATE DATABASE `rockstars_health_check`;

source install/install_table_manager.sql;
source install/install_table_visit.sql;
source install/install_user_root.sql;