<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditWidget_Video2Cate.ascx.cs"
    Inherits="Admin_Controls_EditTVWidget_Video2Cate" %>
<header id="topbar">
    <div class="topbar-left">
        <ol class="breadcrumb">
            <li class="crumb-active">
                <a href="javascript:void();"> <asp:Literal ID="litModules" runat="server"></asp:Literal></a>
            </li>
                        
        </ol>
    </div>
    <div class="topbar-right">

        <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btn_edit" runat="server" OnClick='btn_edit_Click' CssClass="pl5" title="Cập nhật" ValidationGroup="update"> 
                <i class="fa fa-save fs22 text-primary"></i><br /><span class="fs11">Cập nhật</span>
            </asp:LinkButton>
        </div> 
        
        <div class="topbar-icon ml15 ib va-m">
            <a href="JavaScript:window.close();" class="pl5" title="Đóng"> 
                <i class="fa fa-remove fs22 text-danger"></i><br /><span class="fs11">Đóng</span>
            </a>
        </div>
    </div>
</header>
<!-- Begin: Content -->
<section id="content">

<!-- Dashboard Tiles -->
<div class="row mb10">
    
    <div class="panel">
        <div class="panel-body">
            <asp:Literal ID="error" runat="server"></asp:Literal>

            <div class="form-horizontal">
                 <div class="row">
                    <div class="col-lg-6 col-md-6 col-sm-6">
                        <div class="form-group">
                            <label class="col-lg-4 col-md-4 col-sm-4 control-label pt5" for="inputSmall">Chọn Page</label>
                            <div class="col-lg-8 col-md-8 col-sm-8">
                                  <asp:DropDownList ID="ddlPageLayout" runat="server" ValidationGroup="update"
                                     CssClass="form-control input-sm" Enabled="false">
                                </asp:DropDownList>
                            </div>
                        </div>
                     </div>
                   <div class="col-lg-6 col-md-6 col-sm-6">
                        <div class="form-group">
                            <label class="col-lg-4 col-md-4 col-sm-4 control-label pt5" for="inputSmall">Tiêu đề</label>
                            <div class="col-lg-8 col-md-8 col-sm-8">
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtWidgetTitle"
                                        ErrorMessage="RequiredFieldValidator" ValidationGroup="update"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                 <asp:TextBox ID="txtWidgetTitle" runat="server" CssClass="form-control input-sm" placeholder="Nhập tiêu đề" ValidationGroup="update"></asp:TextBox>
                            </div>
                        </div>
                     </div>
                       
                </div>

                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="form-group">
                                <label class="col-lg-4 col-md-4 col-sm-4 control-label pt5" for="inputSmall">Chọn vùng (Region)</label>
                                <div class="col-lg-8 col-md-8 col-sm-8">
                                      <asp:DropDownList ID="ddlRegion" runat="server" ValidationGroup="update"
                                         CssClass="form-control input-sm" Enabled="false">
                                    </asp:DropDownList>
                                </div>
                            </div>
                         </div>
                       <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="form-group">
                                <label class="col-lg-4 col-md-4 col-sm-4 control-label pt5" for="inputSmall">Trạng thái</label>
                                <div class="col-lg-8 col-md-8 col-sm-8">
                                     <div class="checkbox-custom pt5">
                                    <asp:CheckBox ID="chkStatus" runat="server" Checked="true" Text="Hiển thị/Ẩn" ValidationGroup="update"/>
                                </div>
                                </div>
                            </div>
                         </div>
                    </div>
                
                <div class="row">
                    <div class="col-lg-6 col-md-6 col-sm-6">
                        <div class="form-group">
                            <label class="col-lg-4 col-md-4 col-sm-4 control-label pt5" for="inputSmall">Chọn Widget</label>
                            <div class="col-lg-8 col-md-8 col-sm-8">
                                 <asp:DropDownList ID="ddlWidget" runat="server" ValidationGroup="update"
                                     CssClass="form-control input-sm" Enabled="false">
                                </asp:DropDownList>
                            </div>
                        </div>
                     </div>
                    <div class="col-lg-6 col-md-6 col-sm-6">
                    </div>
                </div>
                 <div class="row">
                    <div class="col-lg-6 col-md-6 col-sm-6">
                        <div class="form-group">
                            <label class="col-lg-4 col-md-4 col-sm-4 control-label pt5" for="inputSmall">Chọn Abum Video</label>
                            <div class="col-lg-8 col-md-8 col-sm-8">
                                <asp:ListBox ID="lboGallary" runat="server" Height="200px" class="form-control input-sm" ValidationGroup="update">
                                </asp:ListBox>
                            </div>
                        </div>
                     </div>
                   <div class="col-lg-6 col-md-6 col-sm-6">
                        <div class="form-group">
                            <label class="col-lg-4 col-md-4 col-sm-4 control-label pt5" for="inputSmall">Số bản ghi</label>
                             <div class="col-lg-8 col-md-8 col-sm-8">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator24" runat="server"
                                ControlToValidate="txtRecord" ValidationExpression="^\d+$"
                                ValidationGroup="update"><span class="append-icon right text-danger">Nhập kiểu số!</span></asp:RegularExpressionValidator>

                                 <asp:TextBox ID="txtRecord" runat="server" CssClass="form-control input-sm" placeholder="Nhập tiêu đề" ValidationGroup="update"></asp:TextBox>
                            </div>
                        </div>
                     </div>
                </div>
                 <div class="row">
                    <div class="col-lg-6 col-md-6 col-sm-6">
                        <div class="form-group">
                            <label class="col-lg-4 col-md-4 col-sm-4 control-label pt5" for="inputSmall">Chọn Abum Video</label>
                            <div class="col-lg-8 col-md-8 col-sm-8">
                                <asp:ListBox ID="lboGallary2" runat="server" Height="200px" CssClass="form-control input-sm" ValidationGroup="update">
                                </asp:ListBox>
                            </div>
                        </div>
                     </div>
                   <div class="col-lg-6 col-md-6 col-sm-6">
                        <div class="form-group">
                            <label class="col-lg-4 col-md-4 col-sm-4 control-label pt5" for="inputSmall">Số bản ghi</label>
                             <div class="col-lg-8 col-md-8 col-sm-8">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                ControlToValidate="txtRecord2" ValidationExpression="^\d+$"
                                ValidationGroup="update"><span class="append-icon right text-danger">Nhập kiểu số!</span></asp:RegularExpressionValidator>

                                 <asp:TextBox ID="txtRecord2" runat="server" CssClass="form-control input-sm" placeholder="Nhập tiêu đề" ValidationGroup="update"></asp:TextBox>
                            </div>
                        </div>
                     </div>
                </div>
                <div class="row">
                       <div class="col-lg-12 col-md-12 col-sm-12 text-left">
                        <asp:Button runat="server" ID="btn_edit1" CssClass="btn btn-sm btn-primary mr10" Text="Cập nhật" OnClick="btn_edit_Click"  ValidationGroup="update"/>
                         <a href="JavaScript:window.close();" class="btn btn-sm btn-system mr10" title="Đóng">Đóng</a>
                     </div>
                  </div>

                
            </div>
        </div>
    </div>
 
</div>
</section>
<asp:HiddenField ID="txtID" runat="server" />
<asp:HiddenField ID="hddIcon" runat="server" />
<asp:HiddenField ID="hddOrders" runat="server" />

<asp:HiddenField ID="hddRadInfo" runat="server" />
<asp:HiddenField ID="hddRadHTML" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
<asp:HiddenField ID="hddRecord2" runat="server" />
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddValue2" runat="server" />


<script type='text/javascript'>
    function CloseWindow() {
        window.close();
    }
</script>