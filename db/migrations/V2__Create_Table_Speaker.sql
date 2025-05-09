CREATE TABLE `speakers` (
    `id` BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `user_id` BIGINT NOT NULL UNIQUE,
    `company` VARCHAR(255) COLLATE 'utf8mb4_0900_ai_ci' NULL DEFAULT NULL,
    `position` VARCHAR(255) COLLATE 'utf8mb4_0900_ai_ci' NULL DEFAULT NULL,
    `bio` TEXT COLLATE 'utf8mb4_0900_ai_ci' NULL DEFAULT NULL,
    CONSTRAINT `fk_speaker_user`
        FOREIGN KEY (`user_id`) REFERENCES `users` (`id`)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);
