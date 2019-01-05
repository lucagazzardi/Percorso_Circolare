import { CourseDto, LessonDto } from "../models/models";

//Variables
const webApiUri: string = 'http://localhost:5655/api';
let _self = this;
let options = { year: 'numeric', month: '2-digit', day: '2-digit'}


//StartUp
$(document).ready(() => {
    //Loader for API calls
    $('#loader-course').hide();
    $('#loader-lessons').hide();
    _self.getLastCourses();
    _self.getLastLessons();
});


// Retrieve the list of the last 5 inserted courses
function getLastCourses() {

    $('#course-table-container').hide();
    $('#loader-course').show();

    $.getJSON(webApiUri + '/course/get/all')
        .done((courses: CourseDto[]) => {

            // Get first 5 elements
            courses.sort((a: CourseDto, b: CourseDto) => b.Id - a.Id);
            courses = courses.slice(0, 5);

            $.each(courses, (key, item: CourseDto) => {
                $('#courses-table').append('<tr class="g-font"><th scope="row">' + item.Id +
                    '</th><td>' + item.Description + '</td><td class="hidden-sm hidden-xs">' + item.Year + '</td><td>' +
                    new Date(item.BeginDate).toLocaleDateString('it-IT', options) + '</td><td>' + new Date(item.EndDate).toLocaleDateString('it-IT', options) + '</td><td>' + item.ResourceName + '</td></tr>');
            });

            $('#loader-course').hide();
            $('#course-table-container').show();
        })
        .fail(function (jqXHR, textStatus, err) {
            alert('Si è verificato un errore nel caricamento degli ultimi corsi inseriti');
        });
}

// Retrieve the list of the last 5 inserted lessons
function getLastLessons() {

    $('#lesson-table-container').hide();
    $('#loader-lessons').show();

    $.getJSON(webApiUri + '/lesson/get/all')
        .done((lessons: LessonDto[]) => {

            // Get first 5 elements
            lessons.sort((a: LessonDto, b: LessonDto) => b.Id - a.Id);
            lessons = lessons.slice(0, 5);

            $.each(lessons, (key, item: LessonDto) => {
                $('#lessons-table').append('<tr class="g-font"><th scope="row">' + item.Id +
                    '</th><td>' + item.Description + '</td><td>' + new Date(item.LectureDate).toLocaleDateString('it-IT', options) + '</td><td>' +
                    item.Module + '</td><td>' + item.Course + '</td><td class="hidden-sm hidden-xs">' + item.Classroom + '</td><td class="hidden-sm hidden-xs">' + item.Teacher + '</td><td class="hidden-sm hidden-xs">' + item.Backup + '</td></tr>');
            });

            $('#loader-lessons').hide();
            $('#lesson-table-container').show();
        })
        .fail(function (jqXHR, textStatus, err) {
            alert('Si è verificato un errore nel caricamento delle ultime lezioni inserite');
        });
}
