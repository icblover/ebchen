/*
Copyright (c) 2003-2012, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    //config.uiColor = '#AADC6E';
    config.skin = "kama";
    var ckfinderPath = "/Areas/Account/ckfinder/";
    config.filebrowserBrowseUrl = ckfinderPath + "ckfinder.html";
    config.filebrowserImageBrowseUrl = ckfinderPath + "ckfinder.html?type=Images";
    config.filebrowserFlashBrowseUrl = ckfinderPath + "ckfinder.html?type=Flash";
    
    config.filebrowserUploadUrl = ckfinderPath + "core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";
    config.filebrowserImageUploadUrl = ckfinderPath + "core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
    config.filebrowserFlashUploadUrl = ckfinderPath + "core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";
};
