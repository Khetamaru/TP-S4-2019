create view iti.vClassDetail
as
    select
        StudentId = s.StudentId,
        StudentName = s.FirstName + ' ' + s.LastName,
        ClassId = c.ClassId,
        ClassName = c.[Name],
        TeacherId = t.TeacherId,
        TeacherName = t.FirstName + ' ' + t.LastName
        from iti.tStudent s
        inner join iti.tClass c on c.ClassId = s.ClassId
        inner join iti.tTeacher t on t.TeacherId = c.TeacherId
    where s.StudentId <> 0;
