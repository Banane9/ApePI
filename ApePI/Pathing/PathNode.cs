using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApePI.Pathing
{
    //public class PathNode
    //{
    //    private readonly Type type;

    //    private readonly Dictionary<string, NextNode> nextNodes = new Dictionary<string, NextNode>();

    //    public PathNode(Type type)
    //    {
    //        this.type = type;

    //        buildNextNodes();
    //    }

    //    private void buildNextNodes()
    //    {
    //        foreach (var memberInfo in type.GetMembers(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy))
    //        {
    //            var propertyInfo = memberInfo as PropertyInfo;
    //            if (propertyInfo != null)
    //            {
    //                nextNodes.Add(memberInfo.Name, new NextNode(new PathNode(propertyInfo.PropertyType), memberInfo));
    //                continue;
    //            }

    //            var methodInfo = memberInfo as MethodInfo;
    //            if (methodInfo != null)
    //                nextNodes.Add(memberInfo.Name, new NextNode(new PathNode(methodInfo.ReturnType), memberInfo));
    //        }
    //    }

    //    public object FollowPath(object target, IEnumerable<string> path)
    //    {
    //        if (target.GetType() != type)
    //            throw new Exception("Target Object not of correct Type.");

    //        var nextPathEntry = path.First();

    //        if (!nextNodes.ContainsKey(nextPathEntry))
    //            return null;

    //        var newTarget = nextNodes[nextPathEntry].MemberInfo.Handle(target, nextPathEntry);

    //        if (path.Count() < 2)
    //            return newTarget;

    //        return nextNodes[nextPathEntry].PathNode.FollowPath(newTarget, path.Skip(1));
    //    }

    //    private class NextNode
    //    {
    //        public PathNode PathNode { get; private set; }

    //        public MemberInfo MemberInfo { get; private set; }

    //        public NextNode(PathNode pathNode, MemberInfo memberInfo)
    //        {
    //            PathNode = pathNode;
    //            MemberInfo = memberInfo;
    //        }
    //    }
    //}
}