"use strict";

var gulp = require("gulp"),
    sass = require("gulp-sass"),
    concat = require("gulp-concat"),
    uglify = require("gulp-uglify"),
    rename = require("gulp-rename"),
    cleanCss = require("gulp-clean-css");

gulp.task("fa-fonts", function () {
    return gulp.src([
        "wwwroot/lib/Font-Awesome/web-fonts-with-css/webfonts/fa-solid-*.*"])
        .pipe(gulp.dest("wwwroot/build/webfonts"))
        .pipe(gulp.dest("wwwroot/dist/webfonts"));
});

gulp.task("move-js", function () {
    gulp.src([""])
        .pipe(gulp.dest("wwwroot/dist/js"));
});

gulp.task("sass", function () {
    return gulp.src("wwwroot/scss/site.scss")
        .pipe(sass())
        .pipe(rename("site_scss.css"))
        .pipe(gulp.dest("wwwroot/build/css"));
});

gulp.task("copy-css", ["sass"], function () {
    return gulp.src([
        "wwwroot/lib/Font-Awesome/web-fonts-with-css/css/fontawesome-all.css",
        "wwwroot/css/site.css"])
        .pipe(gulp.dest("wwwroot/build/css"));
});

gulp.task("concat-css", ["copy-css"], function () {
    return gulp.src([
        "wwwroot/build/css/site.css",
        "wwwroot/build/css/site_scss.css"])
        .pipe(concat("combined.css"))
        .pipe(gulp.dest("wwwroot/build/css"))
});

gulp.task("minify-css", ["concat-css"], function () {
    return gulp.src([
        "wwwroot/build/css/fontawesome-all.css",
        "wwwroot/build/css/combined.css"])
        .pipe(cleanCss())
        .pipe(rename({ suffix: ".min" }))
        .pipe(gulp.dest("wwwroot/dist/css"));
});

gulp.task("copy-js", function () {
    return gulp.src([
        "wwwroot/lib/jquery/dist/jquery.min.js",
        "wwwroot/lib/jquery-ui/dist/jquery-ui.min.js",
        "wwwroot/lib/bootstrap/dist/js/bootstrap.min.js",
        "wwwroot/lib/markerclustererplus/dist/markerclusterer.min.js"])
        .pipe(gulp.dest("wwwroot/dist/js"));
});

gulp.task("minify-js", ["copy-js"], function () {
    return gulp.src("wwwroot/js/site.js")
        .pipe(uglify())
        .pipe(rename({ suffix: ".min" }))
        .pipe(gulp.dest("wwwroot/dist/js"));
});

gulp.task("watch", function () {
    gulp.watch("wwwroot/scss/*.scss", ["minify-css"]);
});

gulp.task("default", ["minify-js", "minify-css", "fa-fonts"], function (callback) { });
