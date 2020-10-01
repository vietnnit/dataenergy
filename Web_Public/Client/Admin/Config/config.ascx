<%@ Control Language="C#" AutoEventWireup="true" CodeFile="config.ascx.cs" Inherits="Admin_Controls_Config" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<header id="topbar">
    <div class="topbar-left">
        <ol class="breadcrumb">
            <li class="crumb-active">
                <a href="javascript:void();"> <asp:Literal ID="litModules" runat="server"></asp:Literal></a>
            </li>
            <li class="crumb-icon">
                <a href="/Admin/Home/Default.aspx">
                    <span class="glyphicon glyphicon-home"></span>
                </a>
            </li>
                        
        </ol>
    </div>
    <div class="topbar-right">
                    
        <div class="ml15 ib va-m">
            <a href="#" class="pl5" title="Trợ giúp"> <i class="fa fa-exclamation-circle fs22 text-primary"></i>
            </a>
        </div>
    </div>
</header>

<!-- Begin: Content -->
<section id="content">

<!-- Dashboard Tiles -->
<div class="row mb10">

<div class="tab-block mb25">
    <ul class="nav nav-tabs tabs-border">
      

        <li class="active"><a href="#tab1" data-toggle="tab" aria-expanded="true">Cấu hình chung</a></li>
        <li><a href="#tab2" data-toggle="tab" aria-expanded="false">Cấu hình Server</a></li>
        <li><a href="#tab5" data-toggle="tab" aria-expanded="false">Thông tin liên hệ</a></li>
        <li><a href="#tab6" data-toggle="tab" aria-expanded="false">Email liên hệ</a></li>
        <li><a href="#tab7" data-toggle="tab" aria-expanded="false">Thông tin khác</a></li>
        <li class="dropdown active">
            <a class="dropdown-toggle" href="#" role="menu" data-toggle="dropdown" aria-expanded="false"> Cấu hình khác <i class="fa fa-caret-down pl5"></i>
            </a>
            <ul class="dropdown-menu">
                <li><a href="#tab4" data-toggle="tab" aria-expanded="false">Hỗ trợ trực tuyến</a></li>
                <li><a href="#tab3" data-toggle="tab" aria-expanded="false">Cấu hình tin</a></li>
               <li><a href="#tab8" data-toggle="tab" aria-expanded="false">Cấu hình Popup</a></li>
                <li><a href="#tab9" data-toggle="tab" aria-expanded="false">Cấu hình sản phẩm</a></li>
                <li><a href="#tab10" data-toggle="tab" aria-expanded="false">Trạng thái</a></li>
            </ul>
        </li>

        
        
    </ul>
    <div class="tab-content">
        <div id="tab1" class="tab-pane active">
            <div class="form-horizontal">
                 <asp:Literal ID="ltlcommon" runat="server"></asp:Literal>

                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Tiêu đề Website</label>
                    <div class="col-lg-10">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttitleweb"
                            ErrorMessage="RequiredFieldValidator" ValidationGroup="valGen"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>                    
                        <asp:TextBox ID="txttitleweb" runat="server" CssClass="form-control input-sm" placeholder="Nhập tiêu đề Website"></asp:TextBox>                                       
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Từ khóa SEO</label>
                    <div class="col-lg-10">                                     
                        <asp:TextBox ID="txtgoogle" runat="server" CssClass="form-control input-sm" placeholder="Nhập từ khóa SEO" TextMode="MultiLine" Height="50px"></asp:TextBox>                                      
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Lời giới thiệu</label>
                    <div class="col-lg-10">
                        <CKEditor:CKEditorControl ID="txtIntro_desc" runat="server" Height="160px" CssClass="form-control input-sm" Language="en">
                         </CKEditor:CKEditorControl>                                            
                    </div>
                </div>
                 <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Nội dung giới thiệu</label>
                    <div class="col-lg-10">
                        <CKEditor:CKEditorControl ID="txtIntroduction" runat="server" Height="160px" CssClass="form-control input-sm" Language="en">
                         </CKEditor:CKEditorControl>                                            
                    </div>
                </div>
                  
                  <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Thông tin công ty</label>
                    <div class="col-lg-10">
                        <CKEditor:CKEditorControl ID="txtInfocompany" runat="server" Height="160px" CssClass="form-control input-sm" Language="en">
                         </CKEditor:CKEditorControl>                           
                    </div>
                </div>     
                     
                <div class="form-group ">
                    <div class="col-lg-12 text-center">
                    <asp:Button runat="server" ID="btn_add1" CssClass="btn btn-sm btn-primary mr10" Text="Lưu cấu hình" OnClick="btn_common_Click" ValidationGroup="valGen" />
                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                    </div>
                </div>
               </div>

        </div>
        <div id="tab2" class="tab-pane">
              <div class="form-horizontal">

                <asp:Literal ID="ltlServer" runat="server"></asp:Literal>

                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Tên Website</label>
                    <div class="col-lg-6">
                           <asp:TextBox ID="txtWebName" runat="server" CssClass="form-control input-sm" placeholder="Nhập tên Website"></asp:TextBox>
                    </div>
                </div>
                
                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">IP máy chủ</label>
                    <div class="col-lg-6">
                           <asp:TextBox ID="txtWebServerIP" runat="server" CssClass="form-control input-sm" placeholder="Nhập IP máy chủ"></asp:TextBox>
                    </div>
                </div>       
                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">IP Mail Server</label>
                    <div class="col-lg-6">
                           <asp:TextBox ID="txtWebMailServer" runat="server" CssClass="form-control input-sm" placeholder="Nhập IP Mail Server"></asp:TextBox>
                    </div>
                </div>   
                
                 <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Domain</label>
                    <div class="col-lg-6">
                           <asp:TextBox ID="txtWebDomain" runat="server" CssClass="form-control input-sm" placeholder="Nhập Domain"></asp:TextBox>
                    </div>
                </div>   
                                           
              <div class="form-group ">
                    <div class="col-lg-12 text-center">
                    <asp:Button runat="server" ID="Button1" CssClass="btn btn-sm btn-primary mr10" Text="Lưu cấu hình" OnClick="btnServer_Click" />
                    <asp:HyperLink ID="HyperLink11" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                    </div>
                </div>
              
            </div>
            
        </div>
        <div id="tab3" class="tab-pane">
            <div class="form-horizontal">

                <asp:Literal ID="ltlnews" runat="server"></asp:Literal>

                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Icons</label>
                    <label class="col-lg-2 control-label" for="inputSmall">Chiều rộng (px)</label>
                    <div class="col-lg-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="new_icon_w"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                           <asp:TextBox ID="new_icon_w" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    <label class="col-lg-2 control-label" for="inputSmall">Chiều cao (px)</label>
                    <div class="col-lg-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="new_icon_h"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                           <asp:TextBox ID="new_icon_h" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Ảnh nhỏ</label>
                    <label class="col-lg-2 control-label" for="inputSmall">Chiều rộng (px)</label>
                    <div class="col-lg-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="new_thumb_w"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                           <asp:TextBox ID="new_thumb_w" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    <label class="col-lg-2 control-label" for="inputSmall">Chiều cao (px)</label>
                    <div class="col-lg-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="new_thumb_h"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                           <asp:TextBox ID="new_thumb_h" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                </div>

                 <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Ảnh to</label>
                    <label class="col-lg-2 control-label" for="inputSmall">Chiều rộng (px)</label>
                    <div class="col-lg-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="new_large_w"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                           <asp:TextBox ID="new_large_w" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    <label class="col-lg-2 control-label" for="inputSmall">Chiều cao (px)</label>
                    <div class="col-lg-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="new_large_h"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                           <asp:TextBox ID="new_large_h" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                </div>
                         
                 <div class="form-group ">
                    <div class="col-lg-12 text-center">
                    <asp:Button runat="server" ID="Button2" CssClass="btn btn-sm btn-primary mr10" Text="Lưu cấu hình" OnClick="btn_news_Click" />
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                    </div>
                </div>  
         
        
            </div>
        </div>
        <div id="tab4" class="tab-pane">

            <div class="form-horizontal">

                <asp:Literal ID="litSupport" runat="server"></asp:Literal>

                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Hỗ trợ trực tuyến</label>
                    <div class="col-lg-10">
                            <CKEditor:CKEditorControl ID="txtRadSupport" runat="server" Height="160px" CssClass="form-control input-sm" Language="en">
                         </CKEditor:CKEditorControl>   
                    </div>
                </div>

                 <div class="form-group ">
                    <div class="col-lg-12 text-center">
                    <asp:Button runat="server" ID="Button3" CssClass="btn btn-sm btn-primary mr10" Text="Lưu cấu hình" OnClick="btn_Support_Click" />
                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                    </div>
                </div>  

            

            </div>
        </div>

        <div id="tab5" class="tab-pane">

             <div class="form-horizontal">

                <asp:Literal ID="litContact" runat="server"></asp:Literal>

                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Thông tin liên hệ</label>
                    <div class="col-lg-10">
                            <CKEditor:CKEditorControl ID="txtRadContact" runat="server" Height="360px" CssClass="form-control input-sm" Language="en">
                         </CKEditor:CKEditorControl>   
                    </div>
                </div>

                 <div class="form-group ">
                    <div class="col-lg-12 text-center">
                    <asp:Button runat="server" ID="Button4" CssClass="btn btn-sm btn-primary mr10" Text="Lưu cấu hình" OnClick="btn_Contact_Click" />
                    <asp:HyperLink ID="HyperLink4" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                    </div>
                </div>  

            </div>
            
            
        </div>

        <div id="tab6" class="tab-pane">

             <div class="form-horizontal">
                 <asp:Literal ID="ltlEmail" runat="server"></asp:Literal>

                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Email gửi thư</label>
                    <div class="col-lg-6">
                   
                        <asp:TextBox ID="txtEmailFrom" runat="server" CssClass="form-control input-sm" placeholder="Nhập Email gửi thư"></asp:TextBox>
                   
                    </div>
                </div>

                 <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Email nhận thư</label>
                    <div class="col-lg-6">
                   
                        <asp:TextBox ID="txtEmailTo" runat="server" CssClass="form-control input-sm" placeholder="Nhập Email nhận thư"></asp:TextBox>
                   
                    </div>
                </div>

                <div class="form-group ">
                    <div class="col-lg-12 text-center">
                    <asp:Button runat="server" ID="Button5" CssClass="btn btn-sm btn-primary mr10" Text="Lưu cấu hình" OnClick="btnemail_Click" />
                    <asp:HyperLink ID="HyperLink5" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                    </div>
                </div>  
            </div>

            
            
        </div>
        <div id="tab7" class="tab-pane">

            <div class="form-horizontal">

                <asp:Literal ID="ltlOther" runat="server"></asp:Literal>

                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Banner Flash</label>
                    <div class="col-lg-10">
                            <CKEditor:CKEditorControl ID="RadCounter" runat="server" Height="160px" CssClass="form-control input-sm" Language="en">
                         </CKEditor:CKEditorControl>   
                    </div>
                </div>

                 <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Info 1</label>
                    <div class="col-lg-10">
                            <CKEditor:CKEditorControl ID="RadInfo1" runat="server" Height="160px" CssClass="form-control input-sm" Language="en">
                         </CKEditor:CKEditorControl>   
                    </div>
                </div>

                 <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Info 2</label>
                    <div class="col-lg-10">
                            <CKEditor:CKEditorControl ID="RadInfo2" runat="server" Height="160px" CssClass="form-control input-sm" Language="en">
                         </CKEditor:CKEditorControl>   
                    </div>
                </div>

                 <div class="form-group ">
                    <div class="col-lg-12 text-center">
                    <asp:Button runat="server" ID="Button6" CssClass="btn btn-sm btn-primary mr10" Text="Lưu cấu hình" OnClick="btn_Other_Click" />
                    <asp:HyperLink ID="HyperLink6" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                    </div>
                </div>  

            </div>

        </div>
        <div id="tab8" class="tab-pane">
             <div class="form-horizontal">

                <asp:Literal ID="ltlPopup" runat="server"></asp:Literal>

                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Trạng thái</label>
                    <div class="col-lg-10">
                            <div class="checkbox-custom checkbox-primary pt10">
                                <asp:CheckBox ID="rdbPopup" runat="server" Text="Bật/Tắt"/>
                            </div>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Nội dung Popup 1:</label>
                    <div class="col-lg-10">
                            <CKEditor:CKEditorControl ID="radPopup" runat="server" Height="360px" CssClass="form-control input-sm" Language="en">
                         </CKEditor:CKEditorControl>   
                    </div>
                </div>

                 <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Nội dung Popup 2:</label>
                    <div class="col-lg-10">
                            <CKEditor:CKEditorControl ID="radPopup2" runat="server" Height="360px" CssClass="form-control input-sm" Language="en">
                         </CKEditor:CKEditorControl>   
                    </div>
                </div>

                 <div class="form-group ">
                    <div class="col-lg-12 text-center">
                    <asp:Button runat="server" ID="Button7" CssClass="btn btn-sm btn-primary mr10" Text="Lưu cấu hình" OnClick="btn_popup_Click" />
                    <asp:HyperLink ID="HyperLink7" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                    </div>
                </div>  

            </div>

        </div>
        <div id="tab9" class="tab-pane">

            <div class="form-horizontal">
                <asp:Literal ID="ltlproduct" runat="server"></asp:Literal>
                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Icons</label>
                    <label class="col-lg-2 control-label" for="inputSmall">Chiều rộng (px)</label>
                    <div class="col-lg-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="product_icon_w"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                           <asp:TextBox ID="product_icon_w" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    <label class="col-lg-2 control-label" for="inputSmall">Chiều cao (px)</label>
                    <div class="col-lg-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="product_icon_h"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                           <asp:TextBox ID="product_icon_h" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Ảnh nhỏ</label>
                    <label class="col-lg-2 control-label" for="inputSmall">Chiều rộng (px)</label>
                    <div class="col-lg-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="product_thumb_w"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                           <asp:TextBox ID="product_thumb_w" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    <label class="col-lg-2 control-label" for="inputSmall">Chiều cao (px)</label>
                    <div class="col-lg-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="product_thumb_h"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                           <asp:TextBox ID="product_thumb_h" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                </div>

                 <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Ảnh to</label>
                    <label class="col-lg-2 control-label" for="inputSmall">Chiều rộng (px)</label>
                    <div class="col-lg-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="product_large_w"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                           <asp:TextBox ID="product_large_w" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    <label class="col-lg-2 control-label" for="inputSmall">Chiều cao (px)</label>
                    <div class="col-lg-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="product_large_h"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                           <asp:TextBox ID="product_large_h" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                </div>

                 <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Số sản phẩm</label>
                   
                    <div class="col-lg-3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtNoproduct"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                           <asp:TextBox ID="txtNoproduct" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    
                </div>
                 <div class="form-group">
                    <label class="col-lg-4 control-label" for="inputSmall">Phân trang (SP/1trang)</label>
                   
                    <div class="col-lg-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtNoPage"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                           <asp:TextBox ID="txtNoPage" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    
                </div>
                  <div class="form-group">
                    <label class="col-lg-4 control-label" for="inputSmall">Đơn vị tiền tệ</label>
                   
                    <div class="col-lg-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtCurrency"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                           <asp:TextBox ID="txtCurrency" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    
                </div>        
                 <div class="form-group ">
                    <div class="col-lg-12 text-center">
                    <asp:Button runat="server" ID="Button8" CssClass="btn btn-sm btn-primary mr10" Text="Lưu cấu hình" OnClick="btnproduct_Click" />
                    <asp:HyperLink ID="HyperLink8" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                    </div>
                </div>  
         
        
            </div>

            
           
        </div>
        <div id="tab10" class="tab-pane">

            <div class="form-horizontal">

                <asp:Literal ID="ltlCloseweb" runat="server"></asp:Literal>

                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Trạng thái</label>
                    <div class="col-lg-10">
                            <div class="checkbox-custom checkbox-primary pt10">
                                <asp:CheckBox ID="rdblistClose" runat="server" Text="Mở/Đóng"/>
                            </div>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Lý do</label>
                    <div class="col-lg-10">
                          <asp:TextBox ID="txtCloseComment" runat="server" CssClass="form-control input-sm" placeholder="Nhập keyword" TextMode="MultiLine" Height="150px"></asp:TextBox>
                    
                    </div>
                </div>

               

                 <div class="form-group ">
                    <div class="col-lg-12 text-center">
                    <asp:Button runat="server" ID="Button9" CssClass="btn btn-sm btn-primary mr10" Text="Lưu cấu hình" OnClick="btnCloseweb" />
                    <asp:HyperLink ID="HyperLink9" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                    </div>
                </div>  

            </div>

        </div>
    </div>
</div>





</div>
</section>

