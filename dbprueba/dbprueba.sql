CREATE TABLE `categoria` IF NOT EXISTS (
	`id` SERIAL,
	`nombre` VARCHAR(50) NOT NULL UNIQUE,
	PRIMARY KEY (`id`)
);
