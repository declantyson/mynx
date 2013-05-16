<%@ Control Language="C#" AutoEventWireup="true" Inherits="mynx.widgets.imageSlider" Codebehind="imageSlider.ascx.cs" %>

<div class="slideshow">
    <div class="slideshow-wrapper">
        <%= slideshowItems %>
        <div class="left-arrow">&lt;</div>
        <div class="right-arrow">&gt;</div>
    </div>
</div>

<script src="/widgets/imageSlider.js"></script>
<link href="/widgets/imageSlider.css" rel="Stylesheet"/>