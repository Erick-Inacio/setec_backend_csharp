ALTER TABLE speakers
ADD COLUMN admin_aproved_uid VARCHAR(36) NULL,
ADD CONSTRAINT fk_speaker_admin_uid
    FOREIGN KEY (admin_aproved_uid)
    REFERENCES users(uid);