"use strict";
var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    sass = require('gulp-sass'),
    rev = require('gulp-rev'),
    usemin = require('gulp-usemin'),
    del = require('del'),
    babel = require("gulp-babel"),
    flatten = require('gulp-flatten'),
    runSequence = require('run-sequence');

Promise = require('es6-promise').Promise;

var paths = {
    webroot: "./wwwroot/"
};
paths.sass = paths.webroot + "css/**/*.scss";
paths.build = paths.webroot + "build";

gulp.task('sass:watch', function () {
    gulp.watch(paths.sass, ['sass']);
});

gulp.task('sass', function () {
    return gulp.src(paths.sass)
      .pipe(sass().on('error', sass.logError))
      .pipe(gulp.dest(paths.webroot + "css"));
});

gulp.task("clean", function (cb) {
    rimraf(paths.build, cb);
});

gulp.task('build:css', function () {
    return gulp.src('Views/Shared/_Style.cshtml')
      .pipe(usemin({
          path: "./wwwroot",
          css: [cssmin, rev, 'concat']
      }))
      .pipe(gulp.dest(paths.build));
});
gulp.task('build:js', function () {
    return gulp.src('Views/Shared/_Script.cshtml')
      .pipe(usemin({
          path: "./wwwroot",
          js: [babel(), rev(), 'concat']
      }))
      .pipe(gulp.dest(paths.build));
});
gulp.task('build:fonts', function () {
    return gulp.src([paths.webroot + '/**/fonts/*'])
        .pipe(flatten())
        .pipe(gulp.dest(paths.webroot + '/fonts/'));
});

gulp.task("build:clean", function () {
    del.sync(paths.build + "/**");
});
gulp.task('build', function (callback) {
    runSequence('build:clean',
                  'build:all',
                callback);
});
gulp.task("build:all", ['sass', 'build:fonts', 'build:css', 'build:js'], function () {
    console.log("Application Built");
});