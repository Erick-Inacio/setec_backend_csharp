create table speaker_social_media (
   speaker_id bigint not null,
   platform   varchar(50) not null,
   url        varchar(255) not null,
   primary key ( speaker_id,
                 platform ),
   foreign key ( speaker_id )
      references speakers ( id )
         on delete cascade
);