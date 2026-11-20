<%@ Page Title="CSV Checker" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="CSVChecker._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .csv-checker-history {
            max-height: 25rem;
            overflow: auto;
        }

        .csv-checker-table > thead th {
            position: sticky;
            top: 0;
            z-index: 1;
            background-color: var(--bs-tertiary-bg, #f8f9fa);
        }

        .csv-checker-table td:first-child {
            max-width: 12rem;
            overflow: hidden;
            text-overflow: ellipsis;
            white-space: nowrap;
            font-family: var(--bs-font-monospace);
            font-size: 0.875rem;
        }

        .csv-checker-table td:nth-child(2) {
            max-width: 14rem;
            overflow: hidden;
            text-overflow: ellipsis;
            white-space: nowrap;
        }

        .csv-checker-table td:nth-child(4) {
            text-align: center;
            font-weight: 600;
        }

        .csv-checker-table td:last-child {
            min-width: 16rem;
        }
    </style>

    <main class="container" aria-labelledby="title">
        <section class="text-center py-5 row">

            <span class="text-primary fw-semibold text-uppercase small">CSV validation tool
            </span>

            <h1 id="title" class="display-5 fw-bold mt-3 mb-3"><%: Title %></h1>

            <p class="text-muted fs-5 mx-auto mb-5" style="max-width: 600px;">
                Upload your CSV file and let CSV Checker analyze its structure
                and data consistency before you transfer it to another application.
           
            </p>
            <asp:Label ID="SuccessMessage" runat="server" CssClass="alert alert-success" Visible="false">Your CSV file is ready for transfer !</asp:Label>
            <asp:Label ID="ErrorMessage" runat="server" CssClass="alert alert-danger" Visible="false"></asp:Label>

        </section>

        <section class="row g-4 align-items-stretch" aria-label="CSV checker tools">
            <div class="col-12 col-xl-5">
                <div class="card border-0 shadow-sm h-100">
                    <div class="card-body p-4 p-lg-5">
                        <h2 class="h4 fw-semibold mb-2">Upload your CSV file
                        </h2>

                        <p class="text-muted mb-4">
                            Select the file you want to analyze.
                        </p>

                        <div class="row g-2 align-items-end">
                            <div class="col-12 col-sm-8">
                                <asp:FileUpload
                                    ID="CsvFileUpload"
                                    runat="server"
                                    CssClass="form-control mw-100"
                                    aria-describedby="csvFileHelp" />
                            </div>
                            <div class="col-12 col-sm-4 d-grid">
                                <asp:Button ID="AnalyzeBtn" runat="server" Text="Analyze my CSV file" OnClick="AnalyzeBtn_Click" CssClass="btn btn-primary w-100" />
                            </div>
                        </div>
                        <div id="csvFileHelp" class="form-text mt-2">
                            Accepted format: .csv
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12 col-xl-7">
                <div class="card border-0 shadow-sm h-100">
                    <div class="card-header bg-white border-0 px-4 px-lg-5 pt-4 pb-0">
                        <h2 class="h5 fw-semibold mb-0">Historique des analyses</h2>
                    </div>
                    <div class="card-body p-4 p-lg-5">
                        <div class="table-responsive csv-checker-history">
                            <asp:Table ID="TableHistory" runat="server" CssClass="table table-hover table-striped align-middle mb-0 csv-checker-table">
                                <asp:TableRow TableSection="TableHeader">
                                    <asp:TableHeaderCell Scope="Column" CssClass="text-nowrap">ID</asp:TableHeaderCell>
                                    <asp:TableHeaderCell Scope="Column" CssClass="text-nowrap">Nom du fichier</asp:TableHeaderCell>
                                    <asp:TableHeaderCell Scope="Column" CssClass="text-nowrap">Date d'analyse</asp:TableHeaderCell>
                                    <asp:TableHeaderCell Scope="Column" CssClass="text-nowrap">Statut</asp:TableHeaderCell>
                                    <asp:TableHeaderCell Scope="Column" CssClass="text-nowrap">Détails</asp:TableHeaderCell>
                                </asp:TableRow>
                            </asp:Table>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <div class="text-center text-muted small mt-4 row">
            <p class="col">CSV Checker — Simple, reliable file validation.</p>
        </div>

    </main>

</asp:Content>
