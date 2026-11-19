<%@ Page Title="CSV Checker" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="CSVChecker._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="DatabaseInfo" runat="server" Visible="false" CssClass="alert alert-info"></asp:Label>

    <main class="container py-5" aria-labelledby="title">
        <section class="text-center py-5">

            <span class="text-primary fw-semibold text-uppercase small">CSV validation tool
            </span>

            <h1 id="title" class="display-5 fw-bold mt-3 mb-3"><%: Title %></h1>

            <p class="text-muted fs-5 mx-auto mb-5" style="max-width: 600px;">
                Upload your CSV file and let CSV Checker analyze its structure
                and data consistency before you transfer it to another application.
           
            </p>

        </section>

        <section>
            <asp:Label ID="SuccessMessage" runat="server" CssClass="alert alert-success" Visible="false">Your CSV file is ready for transfer !</asp:Label>
            <asp:Label ID="ErrorMessage" runat="server" CssClass="alert alert-danger" Visible="false"></asp:Label>
            <div class="border rounded-3 p-4 p-md-5">

                <h2 class="h4 fw-semibold mb-2">Upload your CSV file
                </h2>

                <p class="text-muted mb-4">
                    Select the file you want to analyze.
               
                </p>

                <div class="mb-4">

                    <label for="CsvFileUpload" class="form-label fw-semibold">
                        CSV file
                   
                    </label>
                    <%-- Native component (alias to HTML input file) file transfer in ASP.NET Web Forms --%>
                    <asp:FileUpload
                        ID="CsvFileUpload"
                        runat="server"
                        CssClass="form-control form-control-lg"/>

                    <div class="form-text mt-2">
                        Accepted format: .csv
                   
                    </div>

                </div>

                <%-- Native button (alias to HTML button) in ASP.NET Web Forms --%>
                <asp:Button ID="AnalyzeBtn" runat="server" Text="Analyze my CSV file" OnClick="AnalyzeBtn_Click" CssClass="btn btn-primary btn-lg w-100" />

            </div>

        </section>

        <p class="text-center text-muted small mt-4">
            CSV Checker — Simple, reliable file validation.
       
        </p>

    </main>

</asp:Content>
