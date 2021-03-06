using System;
using System.Collections.Generic;
using VKClient.Audio.Base.DataObjects;
using VKClient.Common.Backend;
using VKClient.Common.Backend.DataObjects;
using VKClient.Common.Framework;
using VKClient.Common.Library;
using VKClient.Video.Library;

namespace VKClient.Video.VideoCatalog
{
  public class AlbumsListHorizontalViewModel : ViewModelBase, ICollectionDataProvider<VKList<VideoAlbum>, AlbumHeader>
  {
    private GenericCollectionViewModel<VKList<VideoAlbum>, AlbumHeader> _albumsCol;
    private long _ownerId;
    private List<User> _knownUsers;
    private List<Group> _knownGroups;

    public GenericCollectionViewModel<VKList<VideoAlbum>, AlbumHeader> CatalogItemsVM
    {
      get
      {
        return this._albumsCol;
      }
    }

    public Func<VKList<VideoAlbum>, ListWithCount<AlbumHeader>> ConverterFunc
		{
			get
			{
				Func<VKList<VideoAlbum>, ListWithCount<AlbumHeader>> arg_1F_0 = new Func<VKList<VideoAlbum>, ListWithCount<AlbumHeader>>((albumsData)=>{
                    ListWithCount<AlbumHeader> listWithCount = new ListWithCount<AlbumHeader>();
                    using (List<VideoAlbum>.Enumerator enumerator = albumsData.items.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            AlbumHeader albumHeader = new AlbumHeader(enumerator.Current, false, false);
                            listWithCount.List.Add(albumHeader);
                        }
                    }
                    listWithCount.TotalCount = albumsData.count;
                    return listWithCount;
                });
				
				return arg_1F_0;
			}
		}

    public AlbumsListHorizontalViewModel(long ownerId, VKList<VideoAlbum> albumsData, List<User> knownUsers, List<Group> knownGroups)
    {
      this._ownerId = ownerId;
      this._knownGroups = knownGroups;
      this._knownUsers = knownUsers;
      this._albumsCol = new GenericCollectionViewModel<VKList<VideoAlbum>, AlbumHeader>((ICollectionDataProvider<VKList<VideoAlbum>, AlbumHeader>) this);
      this.Initialize(albumsData);
    }

    private void Initialize(VKList<VideoAlbum> albumsData)
    {
      this._albumsCol.ReadData(this.ConverterFunc.Invoke(albumsData));
    }

    public void GetData(GenericCollectionViewModel<VKList<VideoAlbum>, AlbumHeader> caller, int offset, int count, Action<BackendResult<VKList<VideoAlbum>, ResultCode>> callback)
    {
      VideoService.Instance.GetAlbums(Math.Abs(this._ownerId), this._ownerId < 0, false, offset, count, callback);
    }

    public string GetFooterTextForCount(GenericCollectionViewModel<VKList<VideoAlbum>, AlbumHeader> caller, int count)
    {
      return "";
    }
  }
}
