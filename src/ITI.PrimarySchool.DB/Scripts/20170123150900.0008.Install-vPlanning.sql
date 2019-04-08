create view iti.vPlanning
as
    select
        PlanningId = p.PlanningId,
        [Date] = p.[Date],
		TeacherId = p.TeacherId,
        TeacherName = t.FirstName + t.LastName
    from iti.tPlanning p
        inner join iti.tTeacher t on t.TeacherId = p.TeacherId
    where p.PlanningId <> 0;