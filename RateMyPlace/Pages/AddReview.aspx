<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Layout.master" AutoEventWireup="true" CodeBehind="AddReview.aspx.cs" Inherits="RateMyPlace.Pages.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Form
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">                  
<div class="modal-header">
    <h5 class="modal-title">Add New Review</h5>
    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
        <span aria-hidden="true">&times;</span>
    </button>
</div>

<div class="modal-body">
                        
    <div class="form-housing-complex-name">
        <label for="complex-name-text">Name of Housing Complex:</label>
        <input id="complex-name-text" type="text" placeholder="Todd">
    </div>
                                
    <div class="form-star-ratings">
        <label for="overall-rating">Overall Rating:</label>
            <i id="overall-rating" class="fas fa-star"></i>
            <i id="overall-rating" class="fas fa-star"></i>
            <i id="overall-rating" class="fas fa-star"></i>
            <i id="overall-rating" class="fas fa-star"></i>
            <i id="overall-rating" class="fas fa-star"></i>
            <br>
        <label for="noise-rating">Noise Rating:</label>
            <i id="overall-rating" class="fas fa-star"></i>
            <i id="overall-rating" class="fas fa-star"></i>
            <i id="overall-rating" class="fas fa-star"></i>
            <i id="overall-rating" class="fas fa-star"></i>
            <i id="overall-rating" class="fas fa-star"></i>
            <br>
        <label for="saftey-rating">Safety Rating:</label>
            <i id="safety-rating" class="fas fa-star"></i>
            <i id="safety-rating" class="fas fa-star"></i>
            <i id="safety-rating" class="fas fa-star"></i>
            <i id="safety-rating" class="fas fa-star"></i>
            <i id="safety-rating" class="fas fa-star"></i>
            <br>
        <label for="maintenance-rating">Maintenance Rating:</label>
            <i id="maintenance-rating" class="fas fa-star"></i>
            <i id="maintenance-rating" class="fas fa-star"></i>
            <i id="maintenance-rating" class="fas fa-star"></i>
            <i id="maintenance-rating" class="fas fa-star"></i>
            <i id="maintenance-rating" class="fas fa-star"></i>
    </div>
                                
    <!--  div class = form-checkboxes form-group  -->
    <!-- input class form-check -->

    <div class="custom-control custom-checkbox">

        <input type="checkbox" class="custom-control-input" id="study-space">
        <label class="custom-control-label" for="study-space">Study Space</label>

        <input type="checkbox" class="custom-control-input" id="shuttle">
        <label class="custom-control-label" for="shuttle">Shutlle</label>

        <input type="checkbox" class="custom-control-input" id="furnished">
        <label class="custom-control-label" for="furnished">Furnished</label>

        <input type="checkbox" class="custom-control-input" id="pet-friendly">
        <label class="custom-control-label" for="pet-friendly">Pet Friendly</label>

        <input type="checkbox" class="custom-control-input" id="gym">
        <label class="custom-control-label" for="gym">Gym</label>
                            
        <input type="checkbox" class="custom-control-input" id="wifi">
        <label class="custom-control-label" for="wifi">Wi-Fi</label>

        <input type="checkbox" class="custom-control-input" id="cable">
        <label class="custom-control-label" for="cable">Cable</label>   
                            
        <input type="checkbox" class="custom-control-input" id="trash">
        <label class="custom-control-label" for="trash">Trash/Recycle Service</label>
                
    </div>
                        
    <div class="form-parking">
            <label for="parking">Parking</label>
            <input id="parking" type="checkbox">
            <input id="parking" type="text" placeholder="100.00"> 
            <small class="form-text text-muted">
                If checked, please provide your average monthly rate (USD).
            </small>
    </div>

    <div class="form-texts">
        <label for="average-monthly-utilities">Avg. Monthly Utilities ($USD)</label> 
        <input id="average-monthly-utilities" type="text" placeholder="120.00"> <br>
        <label for="distance-from-campus">Distance From Campus (mi)</label>
        <input  id="distance-from-campus" type="text" placeholder="0.10"> <br>
    </div>
                                
    <div class="form-lease-length">
        <label for="lease-start-date">Lease Start Date</label>
        <input type="date" id="lease-start-date">
        <br>
        <label for="lease-end-date">Lease End Date</label>
        <input type="date" id="lease-end-date">
        <br>
    </div>
                        
    <div class="form-pros-cons">
        <label for="pros-textarea">Pros:</label>    
        <textarea rows="4" cols="50" id="pros-textarea" maxlength="500" placeholder="I really liked..."></textarea>    
        <br>
        <label for="cons-textarea">Cons:</label>
        <textarea rows="4" cols="50" id="pros-textarea" maxlength="500" placeholder="I did not like..."></textarea>    
    </div>
</div>
                
<div class="modal-footer">
    <button type="button" class="btn btn-primary">Submit</button>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
