module.exports = function(grunt) {
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        watch : {
            styles : {
                files: ['css/*.less'],
                tasks: ['less']
            }
        },
        less : {
            development: {
                options : {
                    paths: ['css/admin_2017.css']
                },
                files : {
                    'admin.css': 'css/admin_2017.less'
                }
            }

        }
    });
    grunt.loadNpmTasks('grunt-contrib-less');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-notify');
    grunt.registerTask('default', ['watch']);
};