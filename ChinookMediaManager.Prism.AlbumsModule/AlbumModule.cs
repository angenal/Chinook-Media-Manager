﻿using ChinookMediaManager.Prism.AlbumsModule.Browse;
using ChinookMediaManager.Prism.AlbumsModule.Toolbar;
using ChinookMediaManager.Prism.Core.Modules;
using Microsoft.Practices.Prism.Regions;

namespace ChinookMediaManager.Prism.AlbumsModule
{
    public class AlbumModule : IChinookModule
    {
        private readonly IRegionManager _regionManager;

        public AlbumModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("ToolBarRegion", typeof(OpenAlbumsToolBarButton));
            _regionManager.RegisterViewWithRegion("ToolBarRegion", typeof(OpenAlbumToolBarButton));
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(AlbumsBrowseView));
        }
    }
}