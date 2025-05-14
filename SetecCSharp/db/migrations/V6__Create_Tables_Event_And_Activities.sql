-- Criar a tabela de eventos
CREATE TABLE events (
    id BIGINT AUTO_INCREMENT PRIMARY KEY,
    initial_date_time DATETIME NOT NULL,
    final_date_time DATETIME NOT NULL,
    name TEXT
);

-- Criar a tabela de atividades
CREATE TABLE activities (
    id BIGINT AUTO_INCREMENT PRIMARY KEY,
    event_id BIGINT NOT NULL,
    activity_type VARCHAR(50) NOT NULL,
    activity_name VARCHAR(255) NOT NULL,
    duration INT,
    local VARCHAR(255),
    aimed_audience VARCHAR(255),
    prerequisite TEXT,
    hard_software_required TEXT,
    description TEXT,
    approved BOOLEAN NOT NULL DEFAULT FALSE,
    FOREIGN KEY (event_id) REFERENCES events(id) ON DELETE CASCADE
);

-- Criar a tabela de relacionamento entre atividades e palestrantes (ManyToMany)
CREATE TABLE activity_speakers (
    activity_id BIGINT NOT NULL,
    speaker_id BIGINT NOT NULL,
    PRIMARY KEY (activity_id, speaker_id),
    FOREIGN KEY (activity_id) REFERENCES activities(id) ON DELETE CASCADE,
    FOREIGN KEY (speaker_id) REFERENCES speakers(id) ON DELETE CASCADE
);

-- Criar a tabela de datas das atividades (List<LocalDateTime>)
CREATE TABLE activity_dates (
    activity_id BIGINT NOT NULL,
    date DATETIME NOT NULL,
    FOREIGN KEY (activity_id) REFERENCES activities(id) ON DELETE CASCADE
);
