<%@ Control Language="C#" AutoEventWireup="true" Inherits="mynx.widgets.imageSlider" Codebehind="imageSlider.ascx.cs" %>

<div class="slideshow">
    <div class="left-arrow"></div>
    <div class="right-arrow"></div>
    <div class="slideshow-wrapper">
        <%= slideshowItems %>
    </div>
</div>

<script src="/widgets/imageSliderAssets/imageSlider.js"></script>
<link href="/widgets/imageSliderAssets/imageSlider.css" rel="Stylesheet"/>