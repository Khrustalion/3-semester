using Itmo.ObjectOrientedProgramming.Lab4.Parser.FileHandlerDir;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.TreeHandlerDir;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class LocalFileSystemHandlerDirector : IFileSystemHandlerDirector
{
    public LocalFileSystemHandlerDirector() { }

    public IHandler BuildHandler()
    {
        var treeListWithDepth = new TreeListWithDepthHandler();
        IHandler treeList = new TreeListHandler().AddNext(treeListWithDepth);
        IHandler treeGoto = new TreeGotoHandler().AddNext(treeList);
        IHandler tree = new TreeHandler().AddNext(treeGoto);

        var fileShow = new FileShowHandler();
        IHandler fileRename = new FileRenameHandler().AddNext(fileShow);
        IHandler fileMove = new FileMoveHandler().AddNext(fileRename);
        IHandler fileDelete = new FileDeleteHandler().AddNext(fileMove);
        IHandler fileCopy = new FileCopyHandler().AddNext(fileDelete);
        IHandler file = new FileHandlerDir.FileHandler(tree).AddNext(fileCopy);

        IHandler connect = new ConnectHandler().AddNext(file);
        IHandler disconnect = new DisconnectHandler().AddNext(connect);

        return disconnect;
    }
}