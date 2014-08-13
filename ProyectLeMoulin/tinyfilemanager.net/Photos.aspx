<%@ Page Title="" Language="C#" MasterPageFile="~/tinyfilemanager.net/_admin.Master" AutoEventWireup="true" CodeBehind="Photos.aspx.cs" Inherits="TinyFileManager.NET.Photos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="robots" content="noindex,nofollow">
        <title>Tiny File Manager</title>
               <link href="css/ekko-lightbox.min.css" rel="stylesheet" type="text/css" />
        <link href="css/style.css" rel="stylesheet" type="text/css" />
		<link href="css/dropzone.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .borderless  {
    border: none;
}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!----- uploader div start ------->
        <div class="uploader">            
	        <form action="Photos.aspx?cmd=upload" method="post" enctype="multipart/form-data" id="myAwesomeDropzone" class="dropzone">
		        <input type="hidden" name="folder" value="<% Response.Write(this.strCurrPath); %>" class="form-control">
		        <div class="fallback">
                    <input type="hidden" name="fback" value="true" class="form-control">
	    	        <input name="file" type="file" multiple="" class="form-control">
                    <br>
                    <input type="submit" name="submit" value="Upload" class="form-control">
	  	        </div>
	        </form>
	        <center><button class="btn btn-primary close-uploader btn-lg"><i class="icon-backward icon-white"></i> Return to files list</button></center>
	        <div class="space10"></div><div class="space10"></div>
        </div>
<!----- uploader div end ------->

       <div class="container"></div>
          
          
<!----- header div start ------->
			<div class="filters">
<% if (this.objConfig.boolAllowUploadFile) { %>
                <button class="btn btn-primary upload-btn btn-default" style="margin-left: 5px;"><i class="glyphicon glyphicon-upload icon-white"></i> Importer un fichier</button>
<% } %>
<% if (this.objConfig.boolAllowCreateFolder)
   { %>
			    <button class="btn new-folder" style="margin-left: 5px;"><i class="glyphicon glyphicon-folder-open"></i> &nbsp Nouvelle Dossier</button>
<% } %>
<% if ((Convert.ToInt32(this.strType) != 1) && (Convert.ToInt32(this.strType) < 3)) { // not only image or only video %>
                <div class="pull-right">Filter: &nbsp;&nbsp;
    <input id="select-type-all" name="radio-sort" type="radio"
    data-item="ff-item-type-all" class="hide" />
    <label label-default="label-default" id="ff-item-type-all" for="select-type-all"
    class="btn btn-info ff-label-type-all">Tous</label>&nbsp;
    <input id="select-type-1" name="radio-sort" type="radio"
    data-item="ff-item-type-1" checked="checked" class="hide" />
    <label label-default="label-default" id="ff-item-type-1" for="select-type-1"
    class="btn btn-default ff-label-type-1">Fichiers</label>&nbsp;
    <input id="select-type-2" name="radio-sort" type="radio"
    data-item="ff-item-type-2" class="hide" />
    <label label-default="label-default" id="ff-item-type-2" for="select-type-2"
    class="btn btn-default ff-label-type-2">Images</label>&nbsp;
    <input id="select-type-3" name="radio-sort" type="radio"
    data-item="ff-item-type-3" class="hide" />
    <label label-default="label-default" id="ff-item-type-3" for="select-type-3"
    class="btn btn-default ff-label-type-3">Archives</label>&nbsp;
    <input id="select-type-4" name="radio-sort" type="radio"
    data-item="ff-item-type-4" class="hide" />
    <label label-default="label-default" id="ff-item-type-4" for="select-type-4"
    class="btn btn-default ff-label-type-4">Videos</label>&nbsp;
    <input id="select-type-5" name="radio-sort" type="radio"
    data-item="ff-item-type-5" class="hide" />
    <label label-default="label-default" id="ff-item-type-5" for="select-type-5"
    class="btn btn-default ff-label-type-5">Music</label>
</div>
<% } %>
            </div>
<!----- header div end ------->

<!----- breadcrumb div start ------->
<div class="row">
    <ul class="breadcrumb">
        <%= this.getBreadCrumb() %>
    </ul>
<!----- breadcrumb div end ------->
            
<div class="row ff-container">
    <div class="col-md-12 pull-right">
        <ul class="thumbnails ff-items list-group">              

                    <%  
                        // loop through folder/file list that we have already created
                        foreach (TinyFileManager.NET.clsFileItem objF in this.arrLinks)
                        {
                            //get start of line html, if necessary
                            Response.Write(this.getStartOfLine(objF.intColNum));

                            // start of item
                            Response.Write("<li class='col-md-2 ff-item-type-" + objF.strClassType + " list-group-item borderless '>");
                            Response.Write("<div class=\"boxes thumbnail \">");
                                    
                            if (objF.boolIsFolder)
                            {
                                // if folder
                                Response.Write(objF.strDeleteLink);
                                Response.Write(objF.strLink);
                            }
                            else
                            {
                                // if file
                                Response.Write(objF.strDownFormOpen);
                                Response.Write("<div class=\"center-block toolbox\">");
                                Response.Write("<button type='submit' title='Download' class='btn btn-default'><i class='glyphicon glyphicon-download'></i></button>");
                                Response.Write(objF.strPreviewLink);
                                Response.Write(objF.strDeleteLink);
                                Response.Write("</div>");
                                Response.Write("</form>");
                                Response.Write(objF.strLink);
                            }      
                                    
                            // end of item
                            Response.Write("</div>");
                            Response.Write("</li>");
                                    
                            //get end of line html, if necessary
                            Response.Write(this.getEndOfLine(objF.intColNum));                                    
                        }
                    %>

                    </ul>
                </div>
            </div>    
        </div>
        
	    <!----- lightbox div end -------> 
 
	    <!----- lightbox div end ------->
        <script type="text/javascript" src="js/ekko-lightbox.min.js"></script>
		<script type="text/javascript" src="js/dropzone.min.js"></script>
        <script type="text/javascript">

            var ext_img=new Array(<% Response.Write(this.objConfig.strAllowedImageExtensions); %>);
            var allowed_ext=new Array(<% Response.Write(this.strAllowedFileExt); %>);
            var track = '<% Response.Write(this.strEditor); %>';
            var curr_dir = '<% Response.Write(this.strCurrPath.Replace("\\", "\\\\")); %>';

            $(document).ready(function () {

                //dropzone config
                Dropzone.options.myAwesomeDropzone = {
                    //forceFallback: true,
                    dictInvalidFileType: "File extension is not allowed",
                    dictFileTooBig: "The upload exceeds the max filesize allowed",
                    dictResponseError: "SERVER ERROR",
                    paramName: "file", // The name that will be used to transfer the file
                    maxFilesize: <% Response.Write(this.objConfig.intMaxUploadSizeMb); %>, // MB
		            accept: function(file, done) {
		                var extension=file.name.split('.').pop();
		                if ($.inArray(extension.toLowerCase(), allowed_ext) > -1) {
		                    done();
		                } else { 
		                    done("File extension is not allowed"); 
		                }
		            }
		        };

                // delegate calls to data-toggle="lightbox"
                $(document).delegate('*[data-toggle="lightbox"]', 'click', function(event) {
                    event.preventDefault();
                    return $(this).ekkoLightbox({
                        onShown: function() {
                            if (window.console) {
                                return console.log('Checking our the events huh?');
                            }
                        }
                    });
                });


                $('input[name=radio-sort]').click(function(){
                    var li=$(this).data('item');
                    $('.filters label').removeClass("btn-info");
                    $('#'+li).addClass("btn-info");
                    if(li=='ff-item-type-all'){ 
                        $('.thumbnails li').fadeTo(500,1); 
                    }else{
                        if($(this).is(':checked')){
                            $('.thumbnails li').not('.'+li).fadeTo(500,0.1);
                            $('.thumbnails li.'+li).fadeTo(500,1);
                        }
                    }
                });

                $('#full-img').click(function () {
                    $('#previewLightbox').lightbox('hide');
                });
                $('.upload-btn').click(function(){
                    $('.uploader').show(500);
                });
                $('.close-uploader').click(function(){
                    $('.uploader').hide(500);
                    window.location = removeVariableFromURL(window.location, 'cmd');
                });
                $('.preview').click(function(){
                    $(".preview").attr("data-remote", $(this).data('url'));
                    console.log($(this).data('url'));
                    return true;
                });
                $('.new-folder').click(function(){
                    folder_name = window.prompt('Insert folder name:', 'New Folder');
                    if(folder_name){
                        folder_path=curr_dir + '\\' + folder_name;
                        $.ajax({
                            type: "POST",
                            url: "Photos.aspx?cmd=createfolder",
                            data: {folder: folder_path}
                        }).done(function (msg) {
                            //TODO: add error handling
                            window.location = removeVariableFromURL(window.location, 'cmd');
                        });
                    }
                });

                var boxes = $('.boxes');
                boxes.height('auto');
                var maxHeight = Math.max.apply(
                  Math, boxes.map(function() {
                      return $(this).height();
                  }).get());
                boxes.height(maxHeight);
            });

            //********************************************
            // functions
            //********************************************
            function apply(file, type_file) {
                <% if (this.objConfig.strFillSelector != "") { %>
                $(<% Response.Write(this.objConfig.strFillSelector); %>).val(file);
                <% Response.Write(this.objConfig.strPopupCloseCode); %>
                <% } else { %>
                var target = window.parent.document.getElementById(track+'_ifr');
                var closed = window.parent.document.getElementsByClassName('mce-tinyfilemanager.net');
                var ext=file.split('.').pop();
                var fill='';
                if($.inArray(ext.toLowerCase(), ext_img) > -1){
                    fill=$("<img />",{"src":file});
                }else{
                    fill=$("<a />").attr("href", file).text(file.replace(/\..+$/, ''));
                }
                $(target).contents().find('#tinymce').append(fill);
                $(closed).find('.mce-close').trigger('click');
                <% } %>
            }

            function apply_link(file,type_file){
                <% if (this.objConfig.strFillSelector != "") { %>
                $(<% Response.Write(this.objConfig.strFillSelector); %>).val(file);
                <% Response.Write(this.objConfig.strPopupCloseCode); %>
                <% } else { %>
                $('.mce-link_'+track, window.parent.document).val(file);
                var closed = window.parent.document.getElementsByClassName('mce-tinyfilemanager.net');
                if($('.mce-text_'+track, window.parent.document).val()=='') $('.mce-text_'+track, window.parent.document).val(file.replace(/\..+$/, ''));
                $(closed).find('.mce-close').trigger('click');
                <% } %>
            }

            function apply_img(file,type_file){
                <% if (this.objConfig.strFillSelector != "") { %>
                $(<% Response.Write(this.objConfig.strFillSelector); %>).val(file);
                <% Response.Write(this.objConfig.strPopupCloseCode); %>
                <% } else { %>
                var target = window.parent.document.getElementsByClassName('mce-img_' + track);
                var closed = window.parent.document.getElementsByClassName('mce-tinyfilemanager.net');
                $(target).val(file);
                $(closed).find('.mce-close').trigger('click');
                <% } %>
            }

            function apply_video(file,type_file){
                <% if (this.objConfig.strFillSelector != "") { %>
                $(<% Response.Write(this.objConfig.strFillSelector); %>).val(file);
                <% Response.Write(this.objConfig.strPopupCloseCode); %>
                <% } else { %>
                var target = window.parent.document.getElementsByClassName('mce-video' + type_file + '_' + track);
                var closed = window.parent.document.getElementsByClassName('mce-tinyfilemanager.net');
                $(target).val(file);
                $(closed).find('.mce-close').trigger('click');
                <% } %>
            }

            function removeVariableFromURL(url_string, variable_name) {
                var URL = String(url_string);
                var regex = new RegExp("\\?" + variable_name + "=[^&]*&?", "gi");
                URL = URL.replace(regex, '?');
                regex = new RegExp("\\&" + variable_name + "=[^&]*&?", "gi");
                URL = URL.replace(regex, '&');
                URL = URL.replace(/(\?|&)$/, '');
                regex = null;
                return URL;
            }

        </script>
</asp:Content>
