﻿module.exports = function (grunt) {
    grunt.initConfig({
        clean: ['wwwroot/lib/bundle/*'],
        cssmin: {
            target: {
                src: ['Assets/css/site.css'],
                dest: 'wwwroot/bundle/bundle.css'
            }
        },
        babel: {
            options: {
                sourceMap: false,
                presets: ['@babel/preset-env']
            },
            dist: {
                files: {
                    'Assets/Temp/chart-new.js': 'Assets/js/chart.js',
                    'Assets/Temp/site-new.js': 'Assets/js/site.js',
                    'Assets/Temp/formreset.js': 'Assets/js/formreset.js'
                }
            }
        },
        concat: {
            all: {
                src: ['Assets/Temp/chart-new.js', 'Assets/Temp/js/site-new.js'],
                dest: 'Assets/Temp/bundle.js'
            }
        },
        uglify: {
            all: {
                files: {
                    'wwwroot/bundle/bundle.min.js': 'Assets/Temp/bundle.js',
                    'wwwroot/js/formreset.min.js': 'Assets/Temp/formreset.js'
                }
            }
        },
        copy: {
            main: {
                files: [
                    { expand: true, src: ['Assets/css/site.css'], dest: 'wwwroot/css/', flatten: true },
                    { expand: true, src: ['Assets/js/chart.js', 'Assets/js/site.js', 'Assets/js/formreset.js'], dest: 'wwwroot/js/', flatten: true }
                ]
            }
        }
    });

    grunt.loadNpmTasks('grunt-contrib-clean');
    grunt.loadNpmTasks('grunt-babel');
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.loadNpmTasks('grunt-contrib-copy');

    grunt.registerTask('production', ['clean', 'babel', 'concat', 'uglify', 'cssmin']);
    grunt.registerTask('development', ['copy'])
};