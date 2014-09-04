//parametres de ouverture du tinymce
tfm_path = '/tinyfilemanager.net';
tinymce.init({
    language: 'fr_FR',
    selector: "textarea#elm1",
    theme: "modern",
    visual_table_class: "table",
    height: 400,
    fontsize_formats: "8pt 10pt 12pt 14pt 18pt 24pt 36pt",
    plugins: [
         "lists colorpicker advlist autolink link image lists charmap print preview hr anchor pagebreak",
         "searchreplace wordcount visualblocks visualchars code insertdatetime media nonbreaking",
         "save table contextmenu directionality emoticons template paste textcolor "
    ],
    content_css: "css/content.css",
    style_formats: [
        {title: 'Headers', items: [
            {title: 'h1', block: 'h1'},
            {title: 'h2', block: 'h2'},
            {title: 'h3', block: 'h3'},
            {title: 'h4', block: 'h4'},
            {title: 'h5', block: 'h5'},
            {title: 'h6', block: 'h6'}
        ]},

        {title: 'Blocks', items: [
            {title: 'p', block: 'p'},
            {title: 'div', block: 'div'},
            {title: 'pre', block: 'pre'}
        ]},

        {title: 'Containers', items: [
            {title: 'section', block: 'section', wrapper: true, merge_siblings: false},
            {title: 'article', block: 'article', wrapper: true, merge_siblings: false},
            {title: 'blockquote', block: 'blockquote', wrapper: true},
            {title: 'hgroup', block: 'hgroup', wrapper: true},
            {title: 'aside', block: 'aside', wrapper: true},
            {title: 'figure', block: 'figure', wrapper: true}
        ]}
    ],
    visualblocks_default_state: true,
    end_container_on_empty_block: true,
    toolbar: "print preview searchreplace tinyfilemanager.net  | undo redo paste | styleselect | bold italic underline | " +
    " alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link unlink " +
    "anchor image media | forecolor backcolor emoticons charmap hr | insertdatetime nonbreaking table |  pagebreak " +
    " visualblocks visualchars code ",

});