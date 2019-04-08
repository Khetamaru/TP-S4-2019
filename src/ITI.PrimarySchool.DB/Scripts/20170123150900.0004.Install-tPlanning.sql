create table iti.tPlanning
(
    PlanningId  int identity(0, 1),
    [Date]		datetime2 not null,
    TeacherId   int not null,

    constraint PK_tPlanning primary key(PlanningId),
    constraint FK_tPlanning_tTeacher foreign key(TeacherId) references iti.tTeacher(TeacherId)
);

insert into iti.tPlanning([Date],     TeacherId)
                   values('00010101', 0);
