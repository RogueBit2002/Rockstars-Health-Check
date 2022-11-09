USE `rockstars_health_check`;

DROP TABLE IF EXISTS `visit`;

CREATE TABLE `visit` (
    `time` DATETIME DEFAULT CURRENT_TIMESTAMP,
	`manager_id` INT UNSIGNED,
	FOREIGN KEY (`manager_id`) REFERENCES `manager`(`id`)
);