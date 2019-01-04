//Variables
const webApiUri = 'http://localhost:5655/api';
let _self = this;
let options = { year: 'numeric', month: '2-digit', day: '2-digit' };
//Enum for status of resources
var ResourceStatus;
(function (ResourceStatus) {
    ResourceStatus[ResourceStatus["Available"] = 1] = "Available";
    ResourceStatus[ResourceStatus["NotAvailable"] = 2] = "NotAvailable";
})(ResourceStatus || (ResourceStatus = {}));
//StartUp
$(document).ready(() => {
    $('#search-bar').keyup(search);
    _self.getCourses();
    _self.getLessons();
    _self.getModules();
    _self.getResources();
});
// Retrieve list of courses
function getCourses() {
    //If #courses-table doesn't exist, it means that this is not courses page, so the call is ignored
    if (!$('#courses-table').length) {
        return;
    }
    $.getJSON(webApiUri + '/course/get/all')
        .done((courses) => {
        $.each(courses, (key, item) => {
            $('#courses-table').append('<tr class="g-font"><th scope="row">' +
                '<div><span class="glyphicon glyphicon-record add-new-icon" data-toggle="modal" data-target="#detail-modal" onclick="openDetailCourse(' + item.Id + ')"></span></div>' +
                '</th><td class="filter">' + item.Description + '</td><td class="hidden-sm hidden-xs">' + item.Year + '</td><td>' +
                new Date(item.BeginDate).toLocaleDateString('it-IT', options) + '</td><td>' + new Date(item.EndDate).toLocaleDateString('it-IT', options) + '</td><td>' + item.ResourceName + '</td></tr>');
        });
    })
        .fail(function (jqXHR, textStatus, err) {
        alert('Si è verificato un errore nel caricamento dei corsi');
    });
}
// Retrieve list of lessons
function getLessons() {
    //If #lessons-table doesn't exist, it means that this is not lessons page, so the call is ignored
    if (!$('#lessons-table').length) {
        return;
    }
    $.getJSON(webApiUri + '/lesson/get/all')
        .done((lessons) => {
        $.each(lessons, (key, item) => {
            $('#lessons-table').append('<tr class="g-font"><th scope="row">' +
                '<div><span class="glyphicon glyphicon-trash delete-icon" onclick="selectDelete(' + item.Id + ')"></span></div></th>' +
                '<td><div><span class="glyphicon glyphicon-record add-new-icon" data-toggle="modal" data-target="#detail-modal" onclick="openDetailLesson(' + item.Id + ')"></span></div>' +
                '</td><td class="filter">' + item.Description + '</td><td class="hidden-sm hidden-xs">' + new Date(item.LectureDate).toLocaleDateString('it-IT', options) + '</td><td class="filter">' +
                item.Module + '</td><td class="filter">' + item.Course + '</td><td class="hidden-sm hidden-xs">' + item.Classroom + '</td><td class="hidden-sm hidden-xs">' + item.Teacher + '</td><td class="hidden-sm hidden-xs">' + item.Backup + '</td></tr>');
        });
    })
        .fail(function (jqXHR, textStatus, err) {
        alert('Si è verificato un errore nel caricamento delle lezioni');
    });
}
// Retrieve list of modules
function getModules() {
    //If #modules-table doesn't exist, it means that this is not modules page, so the call is ignored
    if (!$('#modules-table').length) {
        return;
    }
    $.getJSON(webApiUri + '/module/get/all')
        .done((modules) => {
        $.each(modules, (key, item) => {
            $('#modules-table').append('<tr class="g-font"><th scope="row">' +
                '<div><span class="glyphicon glyphicon-record add-new-icon" data-toggle="modal" data-target="#detail-modal" onclick="openDetailModule(' + item.Id + ')"></span></div>' +
                '</th><td class="filter">' + item.Name + '</td><td class="filter">' + item.Description + '</td><td class="filter">' +
                item.Course + '</td><td>' + item.Credits + '</td><td class="hidden-sm hidden-xs">' + item.LessonNumber + '</td></tr>');
        });
    })
        .fail(function (jqXHR, textStatus, err) {
        alert('Si è verificato un errore nel caricamento dei moduli');
    });
}
// Retrieve list of resources
function getResources() {
    //If #resources-table doesn't exist, it means that this is not resources page, so the call is ignored
    if (!$('#resources-table').length) {
        return;
    }
    $.getJSON(webApiUri + '/resource/get/all')
        .done((resources) => {
        $.each(resources, (key, item) => {
            let status = item.StatusId == ResourceStatus.Available ? 'Disponibile' : 'Non disponibile';
            $('#resources-table').append('<tr class="g-font"><th scope="row">' +
                '<div><span class="glyphicon glyphicon-record add-new-icon" data-toggle="modal" data-target="#detail-modal" onclick="openDetailResource(' + item.Id + ')"></span></div>' +
                '</th><td class="filter">' + item.Username + '</td><td class="filter">' + item.FirstName + '</td><td class="filter">' +
                item.LastName + '</td><td>' + status + '</td></tr>');
        });
    })
        .fail(function (jqXHR, textStatus, err) {
        alert('Si è verificato un errore nel caricamento delle risorse');
    });
}
/// ------------------------
/// - ADD NEW ITEM SCRIPTS -
/// ------------------------
//Dropdown items loading methods
function initAddNewCourse(selector) {
    _self.getResourcesSelect(selector);
}
function initAddNewModule(selector) {
    $('#alert-modal').empty();
    _self.getCoursesSelect(selector);
}
function initAddNewLesson(selectors) {
    $('#alert-modal').empty();
    _self.getCoursesSelect(selectors[0]);
    _self.getResourcesSelect(selectors[1]);
    _self.getResourcesSelect(selectors[2]);
    _self.getModuleSelect(selectors[3]);
    _self.getClassroomSelect();
}
function initAddNewResource() {
    $('#alert-modal').empty();
}
//Resources dropdown
function getResourcesSelect(selector) {
    $(selector).empty();
    $.getJSON(webApiUri + '/resource/get/all')
        .done((courses) => {
        $(selector).append('<option value="0"></option>');
        $.each(courses, (key, item) => {
            if (item.StatusId && item.StatusId == ResourceStatus.NotAvailable) {
                return;
            }
            $(selector).append('<option value="' + item.Id + '">' + item.FirstName + " " + item.LastName + '</option>');
        });
    })
        .fail(function (jqXHR, textStatus, err) {
        alert('Si è verificato un errore nel caricamento delle risorse');
    });
}
//Courses dropdown
function getCoursesSelect(selector) {
    $(selector).empty();
    $.getJSON(webApiUri + '/course/get/all')
        .done((courses) => {
        $(selector).append('<option value="0"></option>');
        $.each(courses, (key, item) => {
            $(selector).append('<option value="' + item.Id + '">' + item.Description + '</option>');
        });
    })
        .fail(function (jqXHR, textStatus, err) {
        alert('Si è verificato un errore nel caricamento dei corsi');
    });
}
//Modules dropdown
function getModuleSelect(selector) {
    $(selector).empty();
    $.getJSON(webApiUri + '/module/get/all')
        .done((courses) => {
        $(selector).append('<option value="0"></option>');
        $.each(courses, (key, item) => {
            $(selector).append('<option value="' + item.Id + '">' + item.Name + '</option>');
        });
    })
        .fail(function (jqXHR, textStatus, err) {
        alert('Si è verificato un errore nel caricamento dei corsi');
    });
}
//Classroom dropdown
function getClassroomSelect() {
    $('#classroom-lesson-input').empty();
    $.getJSON(webApiUri + '/classroom/get/all')
        .done((courses) => {
        $('#classroom-lesson-input').append('<option value="0"></option>');
        $.each(courses, (key, item) => {
            $('#classroom-lesson-input').append('<option value="' + item.Id + '">' + item.Name + '</option>');
        });
    })
        .fail(function (jqXHR, textStatus, err) {
        alert('Si è verificato un errore nel caricamento dei corsi');
    });
}
// -------------------
// - INSERT NEW ITEM -
// -------------------
function createCourse() {
    $.ajax({
        type: "POST",
        url: webApiUri + '/course/insert',
        contentType: 'application/json',
        data: JSON.stringify({
            Description: $('#description-course-input').val(),
            Year: $('#year-course-input').val(),
            BeginDate: new Date($('#begin-course-picker').val().toString()),
            EndDate: new Date($('#end-course-picker').val().toString()),
            ResourceId: $('#resource-course-input').val()
        })
    }).done(function (data) {
        $('#addNew').modal('toggle');
        _self.attachAlert();
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alert("Si è verificato un errore nella creazione del corso");
    });
}
function createModule() {
    if ($('#name-module-input').val() == '' || $('#courses-module-input').val() == 0 || $('#credits-module-input').val() == '') {
        _self.attachAlertModal();
        return;
    }
    $.ajax({
        type: "POST",
        url: webApiUri + '/module/insert',
        contentType: 'application/json',
        data: JSON.stringify({
            Name: $('#name-module-input').val(),
            Description: $('#description-module-input').val(),
            CourseId: $('#courses-module-input').val(),
            Credits: $('#credits-module-input').val(),
            LessonNumber: $('#lessons-module-input').val()
        })
    }).done(function (data) {
        $('#addNew').modal('toggle');
        _self.attachAlert();
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alert("Si è verificato un errore nella creazione del modulo");
    });
}
function createLesson() {
    if ($('#description-lesson-input').val() == '' ||
        $('#module-lesson-input').val() == 0 ||
        $('#courses-lesson-input').val() == 0 ||
        $('#teacher-lesson-input').val() == 0 ||
        $('#backup-lesson-input').val() == 0) {
        _self.attachAlertModal();
        return;
    }
    $.getJSON(webApiUri + '/classroom/get/all')
        .done((courses) => {
        $('#classroom-lesson-input').append('<option value="0"></option>');
        $.each(courses, (key, item) => {
            $('#classroom-lesson-input').append('<option value="' + item.Id + '">' + item.Name + '</option>');
        });
    })
        .fail(function (jqXHR, textStatus, err) {
        alert('Si è verificato un errore nel caricamento dei corsi');
    });
    $.ajax({
        type: "POST",
        url: webApiUri + '/lesson/insert',
        contentType: 'application/json',
        data: JSON.stringify({
            Description: $('#description-lesson-input').val(),
            ModuleId: $('#module-lesson-input').val(),
            CourseId: $('#courses-lesson-input').val(),
            LectureDate: $('#date-lesson-input').val(),
            TeacherId: $('#teacher-lesson-input').val(),
            BackupId: $('#backup-lesson-input').val(),
            ClassroomId: $('#classroom-lesson-input').val()
        })
    }).done(function (data) {
        $('#addNew').modal('toggle');
        _self.attachAlert();
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alert("Si è verificato un errore nella creazione della lezione");
    });
}
function createResource() {
    if ($('#id-resource-input').val() == '' || $('#username-resource-input').val() == '') {
        _self.attachAlertModal();
        return;
    }
    $.ajax({
        type: "POST",
        url: webApiUri + '/resource/insert',
        contentType: 'application/json',
        data: JSON.stringify({
            Id: $('#id-resource-input').val(),
            Username: $('#username-resource-input').val(),
            Firstname: $('#firstname-resource-input').val(),
            Lastname: $('#lastname-resource-input').val(),
            StatusId: ResourceStatus.Available
        })
    }).done(function (data) {
        $('#addNew').modal('toggle');
        _self.attachAlert();
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alert("Si è verificato un errore nella creazione della risorsa");
    });
}
// ------------------------
// - DETAIL VISUALIZATION -
// ------------------------
function openDetailCourse(id) {
    $('#detail-list').empty();
    $('#loader').show();
    $('#detail-list').hide();
    $.getJSON(webApiUri + '/course/get/' + id)
        .done((item) => {
        $('#detail-list').append('<li class="list-group-item"><strong>ID</strong>: ' + item.Id + '</li>' +
            '<li class="list-group-item"><strong>Descrizione</strong>: ' + item.Description + '</li>' +
            '<li class="list-group-item"><strong>Anno di riferimento</strong>: ' + item.Year + '</li>' +
            '<li class="list-group-item"><strong>Data inizio</strong>: ' + new Date(item.BeginDate).toLocaleDateString('it-IT', options) + '</li>' +
            '<li class="list-group-item"><strong>Data fine</strong>: ' + new Date(item.EndDate).toLocaleDateString('it-IT', options) + '</li>' +
            '<li class="list-group-item"><strong>Coordinatore</strong>: ' + item.ResourceName + '</li>');
        $('#detail-list').show();
        $('#loader').hide();
    })
        .fail(function (jqXHR, textStatus, err) {
        alert('Si è verificato un errore nel caricamento del dettaglio');
    });
}
function openDetailModule(id) {
    $('#detail-list').empty();
    $('#loader').show();
    $('#detail-list').hide();
    $.getJSON(webApiUri + '/module/get/' + id)
        .done((item) => {
        $('#detail-list').append('<li class="list-group-item"><strong>ID</strong>: ' + item.Id + '</li>' +
            '<li class="list-group-item"><strong>Nome</strong>: ' + item.Name + '</li>' +
            '<li class="list-group-item"><strong>Descrizione</strong>: ' + item.Description + '</li>' +
            '<li class="list-group-item"><strong>Corso</strong>: ' + item.Course + '</li>' +
            '<li class="list-group-item"><strong>Crediti</strong>: ' + item.Credits + '</li>' +
            '<li class="list-group-item"><strong>Numero lezioni</strong>: ' + item.LessonNumber + '</li>');
        $('#detail-list').show();
        $('#loader').hide();
    })
        .fail(function (jqXHR, textStatus, err) {
        alert('Si è verificato un errore nel caricamento del dettaglio');
    });
}
function openDetailLesson(id) {
    $('#detail-list').empty();
    $('#loader').show();
    $('#detail-list').hide();
    $.getJSON(webApiUri + '/lesson/get/' + id)
        .done((item) => {
        $('#detail-list').append('<li class="list-group-item"><strong>ID</strong>: ' + item.Id + '</li>' +
            '<li class="list-group-item"><strong>Descrizione</strong>: ' + item.Description + '</li>' +
            '<li class="list-group-item"><strong>Modulo</strong>: ' + item.Module + '</li>' +
            '<li class="list-group-item"><strong>Corso</strong>: ' + item.Course + '</li>' +
            '<li class="list-group-item"><strong>Data lezione</strong>: ' + new Date(item.LectureDate).toLocaleDateString('it-IT', options) + '</li>' +
            '<li class="list-group-item"><strong>Docente</strong>: ' + item.Teacher + '</li>' +
            '<li class="list-group-item"><strong>Backup</strong>: ' + item.Backup + '</li>' +
            '<li class="list-group-item"><strong>Aula</strong>: ' + item.Classroom + '</li>');
        $('#detail-list').show();
        $('#loader').hide();
    })
        .fail(function (jqXHR, textStatus, err) {
        alert('Si è verificato un errore nel caricamento del dettaglio');
    });
}
function openDetailResource(id) {
    $('#detail-list').empty();
    $('#loader').show();
    $('#detail-list').hide();
    $.getJSON(webApiUri + '/resource/get/' + id)
        .done((item) => {
        $('#detail-list').append('<li class="list-group-item"><strong>ID</strong>: ' + item.Id + '</li>' +
            '<li class="list-group-item"><strong>Username</strong>: ' + item.Username + '</li>' +
            '<li class="list-group-item"><strong>Nome</strong>: ' + item.FirstName + '</li>' +
            '<li class="list-group-item"><strong>Cognome</strong>: ' + item.LastName + '</li>' +
            '<li class="list-group-item"><strong>Stato</strong>: ' + (item.StatusId == ResourceStatus.Available ? 'Disponibile' : 'Non disponibile') + '</li>');
        $('#detail-list').show();
        $('#loader').hide();
    })
        .fail(function (jqXHR, textStatus, err) {
        alert('Si è verificato un errore nel caricamento del dettaglio');
    });
}
// -----------------
// - DELETE LESSON -
// -----------------
function selectDelete(lessonId) {
    $('#delete-modal').modal('toggle');
    $('#btn-delete-confirm').attr('onclick', 'deleteLesson(' + lessonId + ')');
}
function deleteLesson(lessonId) {
    $.ajax({
        type: "DELETE",
        url: webApiUri + '/lesson/delete/' + lessonId
    }).done(function (data) {
        $('#delete-modal').modal('toggle');
        _self.attachAlertDelete();
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alert("Si è verificato un errore nella cancellazione della lezione");
    });
}
// -----------
// - UTILITY -
// -----------
function search() {
    let value = $('#search-bar').val().toString().toLowerCase();
    $("#table-items tbody tr").filter(function () {
        $(this).toggle($('.filter', this).text().toLowerCase().indexOf(value) > -1);
        return true;
    });
}
function attachAlert() {
    $('<div class="alert alert-success alert-dismissible margin-top-15" role="alert" id="success-alert">' +
        '<strong> Successo! </strong> Il nuovo elemento è stato aggiunto correttamente. La pagina si aggiornerà automaticamente in 5 secondi' +
        '<button type = "button" class="close" data-dismiss="alert" aria-label="close">' +
        '<span aria-hidden="true" >&times;</span>' +
        '</button>' + '</div>').hide().appendTo('#alert').fadeIn(1000);
    $("#success-alert").delay(5000).fadeOut("normal", function () {
        _self.pageRefresh();
    });
}
function attachAlertDelete() {
    $('<div class="alert alert-success alert-dismissible margin-top-15" role="alert" id="success-alert">' +
        '<strong> Successo! </strong> La lezione è stata cancellata correttamente. La pagina si aggiornerà automaticamente in 5 secondi' +
        '<button type = "button" class="close" data-dismiss="alert" aria-label="close">' +
        '<span aria-hidden="true" >&times;</span>' +
        '</button>' + '</div>').hide().appendTo('#alert').fadeIn(1000);
    $("#success-alert").delay(5000).fadeOut("normal", function () {
        _self.pageRefresh();
    });
}
function attachAlertModal() {
    $('<div class="alert alert-danger alert-dismissible margin-top-15" role="alert" id="modal-alert">' +
        '<strong> Errore! </strong> I dati non sono inseriti correttamente. I campi contrassegnati da un asterisco sono obbligatori' +
        '<button type = "button" class="close" data-dismiss="alert" aria-label="close">' +
        '<span aria-hidden="true" >&times;</span>' +
        '</button>' + '</div>').hide().appendTo('#alert-modal').fadeIn(1000);
}
function pageRefresh() {
    location.reload();
}
//# sourceMappingURL=list.js.map