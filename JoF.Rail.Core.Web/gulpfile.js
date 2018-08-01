"use strict";

var gulp = require("gulp"),
    sass = require("gulp-sass"),
    concat = require("gulp-concat"),
    uglify = require("gulp-uglify"),
    rename = require("gulp-rename"),
    cleanCss = require("gulp-clean-css");


gulp.task("sass", function () {
    return gulp.src("wwwroot/scss/site.scss")
        .pipe(sass())
        .pipe(gulp.dest('wwwroot/scss'));
});

gulp.task("minify-css", ["sass"], () => {
    gulp.src([
        "wwwroot/lib/jquery-ui/themes/base/jquery-ui.css",
        "wwwroot/css/site.css",
        "wwwroot/scss/site.css"])
        .pipe(concat("combined.css"))
        .pipe(gulp.dest("wwwroot/dist/css"))
        .pipe(cleanCss({ debug: true }, (details) => {
            console.log(`${details.name}: ${details.stats.originalSize}`);
            console.log(`${details.name}: ${details.stats.minifiedSize}`);
        }))
        .pipe(rename({ suffix: ".min" }))
        .pipe(gulp.dest("wwwroot/dist/css"));
});

gulp.task("minify-js", function () {
    gulp.src("wwwroot/js/site.js")
        .pipe(uglify())
        .pipe(rename({ suffix: ".min" }))
        .pipe(gulp.dest("wwwroot/dist/js"));
});

gulp.task("watch", function () {
    gulp.watch("wwwroot/scss/*.scss", ["minify-css"]);
});

//gulp.task("bootstrap", function () {
//    return gulp.src("wwwroot/lib/bootstrap/scss/*.scss")
//        .pipe(sass())
//        .pipe(concatCss("wwwroot/scss/bootstrap.css"))
//        .pipe(gulp.dest('wwwroot/scss'))
//});

gulp.task("default", ["minify-js", "minify-css"], function (callback) {});
