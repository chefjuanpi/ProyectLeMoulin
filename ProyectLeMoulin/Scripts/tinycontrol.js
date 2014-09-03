//parametres de ouverture du tinymce
tfm_path = '/tinyfilemanager.net';
tinymce.init({
    language: 'fr_FR',
    selector: "textarea#elm1",
    theme: "modern",
    visual_table_class: "table",
    height: 400,
    plugins: [
         "importcss lists colorpicker advlist autolink link image lists charmap print preview hr anchor pagebreak",
         "searchreplace wordcount visualblocks visualchars code insertdatetime media nonbreaking",
         "save table contextmenu directionality emoticons template paste textcolor "
    ],
    nowrap: true,


    toolbar: "print preview searchreplace tinyfilemanager.net  | undo redo paste | styleselect | bold italic underline | " +
    " alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link unlink " +
    "anchor image media | forecolor backcolor emoticons charmap hr | insertdatetime nonbreaking table |  pagebreak " +
    " visualblocks visualchars code ",
    style_formats: [
         { title: 'Bold text', inline: 'b' },
         { title: 'Red text', inline: 'span', styles: { color: '#ff0000' } },
         { title: 'Red header', block: 'h1', styles: { color: '#ff0000' } },
         { title: 'Example 1', inline: 'span', classes: 'example1' },
         { title: 'Example 2', inline: 'span', classes: 'example2' },
         { title: 'Table styles' },
         { title: 'Table row 1', selector: 'tr', classes: 'tablerow1' }
    ],
            theme_advanced_fonts : "Andale Mono=andale mono,times;"+
                "Arial=arial,helvetica,sans-serif;"+
                "Arial Black=arial black,avant garde;"+
                "Book Antiqua=book antiqua,palatino;"+
                "Comic Sans MS=comic sans ms,sans-serif;"+
                "Courier New=courier new,courier;"+
                "Georgia=georgia,palatino;"+
                "Helvetica=helvetica;"+
                "Impact=impact,chicago;"+
                "Symbol=symbol;"+
                "Tahoma=tahoma,arial,helvetica,sans-serif;"+
                "Terminal=terminal,monaco;"+
                "Times New Roman=times new roman,times;"+
                "Trebuchet MS=trebuchet ms,geneva;"+
                "Verdana=verdana,geneva;"+
                "Webdings=webdings;"+
                "Wingdings=wingdings,zapf dingbats",
});