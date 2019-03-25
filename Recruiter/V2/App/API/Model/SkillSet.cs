using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Models.SkillSets
{
public class SkillSet
{

public string Id { get; set; }

public string Node { get; set; }

public string Parent { get; set; }

[NotMapped]
public List<SkillSet> Children{ get; set; }
}

public static class GroupEnumerable
{
public static IList<SkillSet> BuildTree(this IEnumerable<SkillSet> source)
{
var skillsSet = source.GroupBy(i => i.Parent);
var roots = skillsSet.FirstOrDefault(g => g.Key == null).ToList();
if (roots.Count > 0)
{
var dict = skillsSet.Where(g => g.Key != null).ToDictionary(g => g.Key, g => g.ToList());
for (int i = 0; i < roots.Count; i++)
AddChildren(roots[i], dict);
}
return roots;
}
private static void AddChildren(SkillSet node, IDictionary<string, List<SkillSet>> source)
{
if (source.ContainsKey(node.Id))
{
node.Children = source[node.Id];
for (int i = 0; i < node.Children.Count; i++)
AddChildren(node.Children[i], source);
}

else
{
node.Children = new List<SkillSet>();
}
}
}
}