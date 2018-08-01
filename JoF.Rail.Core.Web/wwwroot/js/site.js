
(function () {
    // Open links to different host in a new window.
    $(document.links).filter(function () {
        return this.hostname !== window.location.hostname;
    })
    .attr('target', '_blank');

    //$(".collapse").on("shown.bs.collapse", function (e) {
    //    var $card = $(this).closest(".dummy");
    //    $("html,body").animate({
    //        scrollTop: $card.offset().top - 80
    //    }, 500);
    //});

    $("input.station")
        .autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/api/CrsSearch",
                    dataType: "json",
                    data: {
                        term: request.term
                    },
                    success: function (data) {
                        response(data);
                    },
                    error: function (data, type) {
                        console.log(type);
                    }
                });
            },
            select: function (e, ui) {
                if (ui.item && ui.item.key) {
                    $("#" + $(this).data("target")).val(ui.item.key);
                    $(this).val(ui.item.label);
                }
            },
            create: function () {
                $(this).data("ui-autocomplete")._renderItem = function (ul, item) {
                    var term = this.term;
                    var re = new RegExp(term, "gi");
                    var station = item.label.replace(re, "<strong>$&</strong>");
                    var crs = item.key.replace(re, "<strong>$&</strong>");
                    return $("<li>")
                        .attr("data-value", item.key)
                        .append("<a><span style='width:150px;display:inline-block'>" + station + "</span><span class='float-right'>" + crs + "</span></a>")
                        .appendTo(ul);
                }
            }
        })
        .on("change keyup copy paste cut", function () {
            if (!this.value) {
                $("#" + $(this).data("target")).val("");
            }
        });

    $("#printedOn").html(function () {
        var prefixZero = function (digit) {
            return digit < 10 ? "0" + digit : digit;
        };

        var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];
        var date = new Date();
        return "Printed " + prefixZero(date.getHours()) + ":" + prefixZero(date.getMinutes()) + " on " + prefixZero(date.getDate()) + "-" + months[date.getMonth()] + "-" + prefixZero(date.getYear() % 100);
    });

    setInterval(function () {
        var time = new Date();
        $("#time").html(formatTime(time));
    }, 1000);

})();

var formatTime = function (time) {
    $hr = $("<span>", { "text": prefixZero(time.getHours()) });
    $min = $("<span>", { "text": "." + prefixZero(time.getMinutes()) });
    $sec = $("<small>", { "text": "." + prefixZero(time.getSeconds()) });

    return $hr.append($min).append($sec);
};

var prefixZero = function (digit) {
    return digit < 10 ? "0" + digit : digit;
}

var highlightFields = function (response) {
    $('.form-group').removeClass('invalid');

    $.each(response, function (propName, val) {
        var nameSelector = '[name = "' + propName.replace(/(:|\.|\[|\])/g, "\\$1") + '"]',
            idSelector = '#' + propName.replace(/(:|\.|\[|\])/g, "\\$1");
        var $el = $(nameSelector) || $(idSelector);

        if (val.Errors.length > 0) {
            $el.closest('.form-group').addClass('invalid');
        }
    });
};

var highlightErrors = function (xhr) {
    try {
        var data = JSON.parse(xhr.responseText);
        highlightFields(data);
        showSummary(data);
        window.scrollTo(0, 0);
    } catch (e) {
        // (Hopefully) caught by the generic error handler in `config.js`.
    }
};
var showSummary = function (response) {
    $('#validationSummary').empty().removeClass('d-none');

    var verboseErrors = _.flatten(_.map(response, 'Errors')),
        errors = [];

    var nonNullErrors = _.reject(verboseErrors, function (error) {
        return error.ErrorMessage.indexOf('must not be empty') > -1;
    });

    _.each(nonNullErrors, function (error) {
        errors.push(error.ErrorMessage);
    });

    if (nonNullErrors.length !== verboseErrors.length) {
        errors.push('The highlighted fields are required to submit this form.');
    }

    var $ul = $('#validationSummary').append('<ul></ul>');

    _.each(errors, function (error) {
        var $li = $('<li></li>').text(error);
        $li.appendTo($ul);
    });
};

var redirect = function (data) {
    if (data.redirect) {
        window.location = data.redirect;
    } else {
        //window.scrollTo(0, 0);
        //window.location.reload();
    }
};

//$('form[method=post]').not('.no-ajax').on('submit', function () {
//    var submitBtn = $(this).find('[type="submit"]');

//    submitBtn.prop('disabled', true);
//    $(window).unbind();

//    var $this = $(this),
//        formData = $this.serialize();

//    $this.find('div').removeClass('invalid');
//    $this.addClass("was-validated");

//    $.ajax({
//        url: submitBtn.attr('formaction'),
//        type: 'post',
//        data: formData,
//        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
//        dataType: 'json',
//        statusCode: {
//            200: redirect
//        },
//        complete: function () {
//            submitBtn.prop('disabled', false);
//        },
//        error: function (xhr) {
//            highlightErrors(xhr)
//        }

//    });

//    return false;
//});

//$('form[method=post]').not('.no-ajax').on('submit', function () {
////$(document).ready(function () {
//    var submitBtn = $(this).find('[type="submit"]');

//    submitBtn.prop('disabled', true);
//    $(window).unbind();

//    $(".form-group").removeClass("invalid");

//    $("input.input-validation-error")
//        .closest(".form-group")
//        .addClass("invalid");

//    submitBtn.prop('disabled', false);
//    window.scrollTo(0, 0);
//});
