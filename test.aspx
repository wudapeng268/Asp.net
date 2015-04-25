<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="js/jquery-1.6.2.min.js" type="text/javascript" language="javascript"></script>
<script src="js/basic-jquery-slider.js"  type="text/javascript" language="javascript"></script>
<script type="text/javascript" src="js/custom.js" language="javascript"></script>
<script type="text/javascript" src="js/input.js" language="javascript"></script>

    <title></title>
    <style>
        #filetext{
        width:200px;
        border:1px solid #11586E;
}
#upload{
        display:none;
}
#choosefile{
        width:80px;
        border:0;
        height:18px;
        color:#FFF;
        padding-top:2px;
        background-color:green;        
}

    </style>
    <script type="text/javascript">
        function setValue() {
            //var oForm = document.getElementById("fileupload");
            //$("#upload").click();
                //$("#filetext").val($("#upload").val());
            var oForm = document.getElementById("upload");
            //alert(oForm.elements[1]);
            oForm.click();
            document.getElementById("filetext").value =oForm.value;
            alert(oForm.value);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="fileupload">
        <input id="filetext" type="text"/>
        <input id="upload" type="file" runat="server"/>
        <input id="choosefile" type="button" value="选择文件" onclick="setValue()"  />
        <asp:Button ID="Button2" runat="server" Text="上传" OnClick="Button2_Click" />

    </div>
    </form>
</body>
</html>
