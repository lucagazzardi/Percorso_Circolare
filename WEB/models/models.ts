export class CourseDto {
    Id: number;
    Description: string;
    Year: number;
    BeginDate: Date;
    EndDate: Date;
    ResourceId: number;
    ResourceName: string;
}

export class LessonDto {
    Id: number;
    Description: string;
    Module: string;
    Course: string;
    LectureDate: Date;
    ClassroomId: number;
    Classroom: string;
    Teacher: string;
    Backup: string;
}

export class ModuleDto {
    Id: number;
    Name: string;
    Description: string;
    CourseId: number;
    Course: string;
    Credits: number;
    LessonNumber: number;
}

export class ResourceDto {
    Id: number;
    Username: string;
    FirstName: string;
    LastName: string;
    StatusId: number;
    Status: string;
}

export class ClassroomDto {
    Id: number;
    Name: string;
}