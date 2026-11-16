<%@ Page Title="CSV Checker" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="CSVChecker._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

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

        <section class="mx-auto" style="max-width: 650px;">

            <div class="border rounded-3 p-4 p-md-5">

                <h2 class="h4 fw-semibold mb-2">Upload your CSV file
                </h2>

                <p class="text-muted mb-4">
                    Select the file you want to analyze.
               
                </p>

                <div class="mb-4">

                    <label for="csvFile" class="form-label fw-semibold">
                        CSV file
                   
                    </label>

                    <input
                        type="file"
                        id="csvFile"
                        name="csvFile"
                        class="form-control form-control-lg"
                        accept=".csv"
                        required>

                    <div class="form-text mt-2">
                        Accepted format: .csv
                   
                    </div>

                </div>

                <button type="submit" class="btn btn-primary btn-lg w-100">
                    Analyze my CSV file
               
                </button>

            </div>

        </section>

        <p class="text-center text-muted small mt-4">
            CSV Checker — Simple, reliable file validation.
       
        </p>

    </main>

</asp:Content>
