<<<<<<< HEAD
<?cs include:"doctype.cs" ?>
<?cs include:"macros.cs" ?>
<?cs include:"macros_override.cs" ?>
<html<?cs if:devsite ?> devsite<?cs /if ?>>
<?cs include:"head_tag.cs" ?>
<body class="gc-documentation <?cs if:(reference.gms || reference.gcm) ?>google<?cs /if ?>
  <?cs if:(guide||develop||training||reference||tools||sdk) ?>develop<?cs
    if:reference ?> reference<?cs
    /if ?><?cs
  elif:design ?>design<?cs
  elif:distribute ?>distribute<?cs
  /if ?>" itemscope itemtype="http://schema.org/Article">
  <div id="doc-api-level" class="<?cs var:class.since ?>" style="display:none"></div>
  <a name="top"></a>
<?cs include:"header.cs" ?>

<div class="col-12"  id="doc-col">

<div id="api-info-block">

<?cs # are there inherited members ?>
<?cs each:cl=class.inherited ?>
  <?cs if:subcount(cl.methods) ?>
   <?cs set:inhmethods = #1 ?>
  <?cs /if ?>
  <?cs if:subcount(cl.constants) ?>
   <?cs set:inhconstants = #1 ?>
  <?cs /if ?>
  <?cs if:subcount(cl.fields) ?>
   <?cs set:inhfields = #1 ?>
  <?cs /if ?>
  <?cs if:subcount(cl.attrs) ?>
   <?cs set:inhattrs = #1 ?>
  <?cs /if ?>
<?cs /each ?>

<div class="sum-details-links">
<?cs if:inhattrs || inhconstants || inhfields || inhmethods || (!class.subclasses.hidden &&
     (subcount(class.subclasses.direct) || subcount(class.subclasses.indirect))) ?>
Summary:
<?cs if:subcount(class.inners) ?>
  <a href="#nestedclasses">Nested Classes</a>
  <?cs set:linkcount = #1 ?>
<?cs /if ?>
<?cs if:subcount(class.attrs) ?>
  <?cs if:linkcount ?>&#124; <?cs /if ?><a href="#lattrs">XML Attrs</a>
  <?cs set:linkcount = #1 ?>
<?cs /if ?>
<?cs if:inhattrs ?>
  <?cs if:linkcount ?>&#124; <?cs /if ?><a href="#inhattrs">Inherited XML Attrs</a>
  <?cs set:linkcount = #1 ?>
<?cs /if ?>
<?cs if:subcount(class.enumConstants) ?>
  <?cs if:linkcount ?>&#124; <?cs /if ?><a href="#enumconstants">Enums</a>
  <?cs set:linkcount = #1 ?>
<?cs /if ?>
<?cs if:subcount(class.constants) ?>
  <?cs if:linkcount ?>&#124; <?cs /if ?><a href="#constants">Constants</a>
  <?cs set:linkcount = #1 ?>
<?cs /if ?>
<?cs if:inhconstants ?>
  <?cs if:linkcount ?>&#124; <?cs /if ?><a href="#inhconstants">Inherited Constants</a>
  <?cs set:linkcount = #1 ?>
<?cs /if ?>
<?cs if:subcount(class.fields) ?>
  <?cs if:linkcount ?>&#124; <?cs /if ?><a href="#lfields">Fields</a>
  <?cs set:linkcount = #1 ?>
<?cs /if ?>
<?cs if:inhfields ?>
  <?cs if:linkcount ?>&#124; <?cs /if ?><a href="#inhfields">Inherited Fields</a>
  <?cs set:linkcount = #1 ?>
<?cs /if ?>
<?cs if:subcount(class.ctors.public) ?>
  <?cs if:linkcount ?>&#124; <?cs /if ?><a href="#pubctors">Ctors</a>
  <?cs set:linkcount = #1 ?>
<?cs /if ?>
<?cs if:subcount(class.ctors.protected) ?>
  <?cs if:linkcount ?>&#124; <?cs /if ?><a href="#proctors">Protected Ctors</a>
  <?cs set:linkcount = #1 ?>
<?cs /if ?>
<?cs if:subcount(class.methods.public) ?>
  <?cs if:linkcount ?>&#124; <?cs /if ?><a href="#pubmethods">Methods</a>
  <?cs set:linkcount = #1 ?>
<?cs /if ?>
<?cs if:subcount(class.methods.protected) ?>
  <?cs if:linkcount ?>&#124; <?cs /if ?><a href="#promethods">Protected Methods</a>
  <?cs set:linkcount = #1 ?>
<?cs /if ?>
<?cs if:inhmethods ?>
  <?cs if:linkcount ?>&#124; <?cs /if ?><a href="#inhmethods">Inherited Methods</a>
<?cs /if ?>
&#124; <a href="#" onclick="return toggleAllClassInherited()" id="toggleAllClassInherited">[Expand All]</a>
<?cs /if ?>
</div><!-- end sum-details-links -->
<div class="api-level">
  <?cs call:since_tags(class) ?><?cs
  if:class.deprecatedsince
    ?><br>Deprecated since <a href="<?cs var:toroot ?>guide/topics/manifest/uses-sdk-element.html#ApiLevels"
        >API level <?cs var:class.deprecatedsince ?></a><?cs
  /if ?>
  <?cs call:federated_refs(class) ?>
</div>
</div><!-- end api-info-block -->

<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<!-- ======== START OF CLASS DATA ======== -->

<div id="jd-header">
    <?cs var:class.scope ?>
    <?cs var:class.static ?> 
    <?cs var:class.final ?> 
    <?cs var:class.abstract ?>
    <?cs var:class.kind ?>
<h1 itemprop="name"><?cs var:class.name ?></h1>

<?cs set:colspan = subcount(class.inheritance) ?>
<?cs each:supr = class.inheritance ?>
  <?cs if:colspan == 2 ?>
    extends <?cs call:type_link(supr.short_class) ?><br/>
  <?cs /if ?>
  <?cs if:last(supr) && subcount(supr.interfaces) ?>
      implements 
      <?cs each:t=supr.interfaces ?>
        <?cs call:type_link(t) ?> 
      <?cs /each ?>
  <?cs /if ?>
  <?cs set:colspan = colspan-1 ?>
<?cs /each ?>
<?cs call:show_annotations_list(class) ?>

</div><!-- end header -->

<div id="naMessage"></div>

<div id="jd-content" class="api apilevel-<?cs var:class.since ?>">
<table class="jd-inheritance-table">
<?cs set:colspan = subcount(class.inheritance) ?>
<?cs each:supr = class.inheritance ?>
    <tr>
        <?cs loop:i = 1, (subcount(class.inheritance)-colspan), 1 ?>
            <td class="jd-inheritance-space">&nbsp;<?cs if:(subcount(class.inheritance)-colspan) == i ?>&nbsp;&nbsp;&#x21b3;<?cs /if ?></td>
        <?cs /loop ?> 	
        <td colspan="<?cs var:colspan ?>" class="jd-inheritance-class-cell"><?cs
            if:colspan == 1
                ?><?cs call:class_name(class.qualifiedType) ?><?cs 
            else 
                ?><?cs call:type_link(supr.class) ?><?cs
            /if ?></td>
    </tr>
    <?cs set:colspan = colspan-1 ?>
<?cs /each ?>
</table>

<?cs # this next line must be exactly like this to be parsed by eclipse ?>

<?cs if:subcount(class.subclasses.direct) && !class.subclasses.hidden ?>
<table class="jd-sumtable jd-sumtable-subclasses"><tr><td colspan="12" style="border:none;margin:0;padding:0;">
<?cs call:expando_trigger("subclasses-direct", "closed") ?>Known Direct Subclasses
<?cs call:expandable_class_list("subclasses-direct", class.subclasses.direct, "list") ?>
</td></tr></table>
<?cs /if ?>

<?cs if:subcount(class.subclasses.indirect) && !class.subclasses.hidden ?>
<table class="jd-sumtable jd-sumtable-subclasses"><tr><td colspan="12" style="border:none;margin:0;padding:0;">
<?cs call:expando_trigger("subclasses-indirect", "closed") ?>Known Indirect Subclasses
<?cs call:expandable_class_list("subclasses-indirect", class.subclasses.indirect, "list") ?>
</td></tr></table>
<?cs /if ?>

<div class="jd-descr">
<?cs call:deprecated_warning(class) ?>
<?cs if:subcount(class.descr) || subcount(class.annotationdocumentation) ?>
<h2>Class Overview</h2>
<?cs if:subcount(class.descr) ?><p itemprop="articleBody"><?cs call:tag_list(class.descr) ?></p><?cs /if ?>
<?cs if:subcount(class.annotationdocumentation) ?><?cs each:annodoc = class.annotationdocumentation?>
<p><?cs var:annodoc.text ?></p>
<?cs /each?><?cs /if?>
<?cs /if ?>

<?cs call:see_also_tags(class.seeAlso) ?>
</div><!-- jd-descr -->


<?cs # summary macros ?>

<?cs def:write_method_summary(methods, included) ?>
<?cs set:count = #1 ?>
<?cs each:method = methods ?>
	 <?cs # The apilevel-N class MUST BE LAST in the sequence of class names ?>
    <tr class="<?cs if:count % #2 ?>alt-color<?cs /if ?> api apilevel-<?cs var:method.since ?>" >
        <td class="jd-typecol"><nobr>
            <?cs var:method.abstract ?>
            <?cs var:method.synchronized ?>
            <?cs var:method.final ?>
            <?cs var:method.static ?>
            <?cs call:type_link(method.generic) ?>
            <?cs call:type_link(method.returnType) ?></nobr>
        </td>
        <td class="jd-linkcol" width="100%"><nobr>
        <span class="sympad"><?cs call:cond_link(method.name, toroot, method.href, included) ?></span>(<?cs call:parameter_list(method.params) ?>)</nobr>
        <?cs if:subcount(method.shortDescr) || subcount(method.deprecated) || subcount(method.showAnnotations) ?>
          <div class="jd-descrdiv">
            <?cs if:subcount(method.shortDescr) || subcount(method.annotationdocumentation) ?><?cs call:short_descr(method)?><?cs /if?>
            <?cs call:show_annotations_list(method) ?>
          </div>
        <?cs /if ?>
  </td></tr>
<?cs set:count = count + #1 ?>
<?cs /each ?>
<?cs /def ?>

<?cs def:write_field_summary(fields, included) ?>
<?cs set:count = #1 ?>
    <?cs each:field=fields ?>
      <tr class="<?cs if:count % #2 ?>alt-color<?cs /if ?> api apilevel-<?cs var:field.since ?>" >
          <td class="jd-typecol"><nobr>
          <?cs var:field.scope ?>
          <?cs var:field.static ?>
          <?cs var:field.final ?>
          <?cs call:type_link(field.type) ?></nobr></td>
          <td class="jd-linkcol"><?cs call:cond_link(field.name, toroot, field.href, included) ?></td>
          <td class="jd-descrcol" width="100%">
            <?cs call:short_descr(field) ?>
            <?cs call:show_annotations_list(field) ?>
          </td>
      </tr>
      <?cs set:count = count + #1 ?>
    <?cs /each ?>
<?cs /def ?>

<?cs def:write_constant_summary(fields, included) ?>
<?cs set:count = #1 ?>
    <?cs each:field=fields ?>
    <tr class="<?cs if:count % #2 ?>alt-color<?cs /if ?> api apilevel-<?cs var:field.since ?>" >
        <td class="jd-typecol"><?cs call:type_link(field.type) ?></td>
        <td class="jd-linkcol"><?cs call:cond_link(field.name, toroot, field.href, included) ?></td>
        <td class="jd-descrcol" width="100%">
          <?cs call:short_descr(field) ?>
          <?cs call:show_annotations_list(field) ?>
=======
<?cs # THIS CREATES A CLASS OR INTERFACE PAGE FROM .java FILES ?>
<?cs include:"macros.cs" ?>
<?cs include:"macros_override.cs" ?>
<?cs
####################
# MACRO FUNCTION USED ONLY IN THIS TEMPLATE TO GENERATE API REFERENCE
# FIRST, THE FUNCTIONS FOR THE SUMMARY AT THE TOP OF THE PAGE
####################
?>

<?cs
# Prints the table cells for the summary of methods.
?><?cs def:write_method_summary(methods, included) ?>
<?cs set:count = #1 ?>
<?cs each:method = methods ?>
  <?cs # The apilevel-N class MUST BE LAST in the sequence of class names ?>
  <tr class="api apilevel-<?cs var:method.since ?>" >
  <?cs # leave out this cell if there is no return type = if constructors ?>
  <?cs if:subcount(method.returnType) ?>
    <td><code>
        <?cs var:method.abstract ?>
        <?cs var:method.default ?>
        <?cs var:method.static ?>
        <?cs var:method.final ?>
        <?cs call:type_link(method.generic) ?>
        <?cs call:type_link(method.returnType) ?></code>
    </td>
  <?cs /if ?>
    <td width="100%">
      <code>
      <?cs call:cond_link(method.name, toroot, method.href, included) ?>(<?cs call:parameter_list(method.params, 0) ?>)
      </code>
      <?cs if:subcount(method.shortDescr) || subcount(method.deprecated) ?>
        <p><?cs call:short_descr(method) ?>
        <?cs call:show_annotations_list(method) ?></p>
      <?cs /if ?>
    </td>
  </tr>
  <?cs set:count = count + #1 ?>
<?cs /each ?>
<?cs /def ?>

<?cs
# Print the table cells for the summary of fields.
?><?cs def:write_field_summary(fields, included) ?>
<?cs set:count = #1 ?>
<?cs each:field=fields ?>
  <tr class="api apilevel-<?cs var:field.since ?>" >
    <td><code>
    <?cs var:field.scope ?>
    <?cs var:field.static ?>
    <?cs var:field.final ?>
    <?cs call:type_link(field.type) ?></code></td>
    <td width="100%">
      <code><?cs call:cond_link(field.name, toroot, field.href, included) ?></code>
      <p><?cs call:short_descr(field) ?>
      <?cs call:show_annotations_list(field) ?></p>
    </td>
  </tr>
  <?cs set:count = count + #1 ?>
<?cs /each ?>
<?cs /def ?>

<?cs
# Print the table cells for the summary of constants
?><?cs def:write_constant_summary(fields, included) ?>
<?cs set:count = #1 ?>
    <?cs each:field=fields ?>
    <tr class="api apilevel-<?cs var:field.since ?>" >
        <td><code><?cs call:type_link(field.type) ?></code></td>
        <td width="100%">
          <code><?cs call:cond_link(field.name, toroot, field.href, included) ?></code>
          <p><?cs call:short_descr(field) ?>
          <?cs call:show_annotations_list(field) ?></p>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
        </td>
    </tr>
    <?cs set:count = count + #1 ?>
    <?cs /each ?>
<?cs /def ?>

<<<<<<< HEAD
<?cs def:write_attr_summary(attrs, included) ?>
<?cs set:count = #1 ?>
    <tr>
        <td><nobr><em>Attribute Name</em></nobr></td>
        <td><nobr><em>Related Method</em></nobr></td>
        <td><nobr><em>Description</em></nobr></td>
    </tr>
    <?cs each:attr=attrs ?>
    <tr class="<?cs if:count % #2 ?>alt-color<?cs /if ?> api apilevel-<?cs var:attr.since ?>" >
        <td class="jd-linkcol"><?cs if:included ?><a href="<?cs var:toroot ?><?cs var:attr.href ?>"><?cs /if ?><?cs var:attr.name ?><?cs if:included ?></a><?cs /if ?></td>
        <td class="jd-linkcol"><?cs each:m=attr.methods ?>
            <?cs call:cond_link(m.name, toroot, m.href, included) ?>
            <?cs /each ?>
        </td>
        <td class="jd-descrcol" width="100%">
=======
<?cs
# Print the table cells for the summary of attributes
?><?cs def:write_attr_summary(attrs, included) ?>
<?cs set:count = #1 ?>
    <?cs each:attr=attrs ?>
    <tr class="api apilevel-<?cs var:attr.since ?>" >
        <td><?cs if:included ?><a href="<?cs var:toroot ?><?cs var:attr.href ?>"><?cs /if
          ?><code><?cs var:attr.name ?></code><?cs if:included ?></a><?cs /if ?></td>
        <td width="100%">
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
          <?cs call:short_descr(attr) ?>&nbsp;
          <?cs call:show_annotations_list(attr) ?>
        </td>
    </tr>
    <?cs set:count = count + #1 ?>
    <?cs /each ?>
<?cs /def ?>

<<<<<<< HEAD
<?cs def:write_inners_summary(classes) ?>
<?cs set:count = #1 ?>
  <?cs each:cl=class.inners ?>
    <tr class="<?cs if:count % #2 ?>alt-color<?cs /if ?> api apilevel-<?cs var:cl.since ?>" >
      <td class="jd-typecol"><nobr>
        <?cs var:cl.scope ?>
        <?cs var:cl.static ?> 
        <?cs var:cl.final ?> 
        <?cs var:cl.abstract ?>
        <?cs var:cl.kind ?></nobr></td>
      <td class="jd-linkcol"><?cs call:type_link(cl.type) ?></td>
      <td class="jd-descrcol" width="100%">
        <?cs call:short_descr(cl) ?>&nbsp;
        <?cs call:show_annotations_list(cl) ?>
=======
<?cs
# Print the table cells for the inner classes
?><?cs def:write_inners_summary(classes) ?>
<?cs set:count = #1 ?>
  <?cs each:cl=class.inners ?>
    <tr class="api apilevel-<?cs var:cl.since ?>" >
      <td class="jd-typecol"><code>
        <?cs var:cl.scope ?>
        <?cs var:cl.static ?>
        <?cs var:cl.final ?>
        <?cs var:cl.abstract ?>
        <?cs var:cl.kind ?></code></td>
      <td class="jd-descrcol" width="100%">
        <code><?cs call:type_link(cl.type) ?></code>
        <p><?cs call:short_descr(cl) ?>&nbsp;
        <?cs call:show_annotations_list(cl) ?></p>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
      </td>
    </tr>
    <?cs set:count = count + #1 ?>
    <?cs /each ?>
<?cs /def ?>
<<<<<<< HEAD

<?cs # end macros ?>

<div class="jd-descr">
<?cs # make sure there's a summary view to display ?>
=======
<?cs
###################
# END OF FUNCTIONS FOR API SUMMARY
# START OF FUNCTIONS FOR THE API DETAILS
###################
?>
<?cs
# Print the table cells for the summary of constants
?>
<?cs def:write_field_details(fields) ?>
<?cs each:field=fields ?>
<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<?cs # the A tag in the next line must remain where it is, so that Eclipse can parse the docs ?>
<A NAME="<?cs var:field.anchor ?>"></A>
<?cs # The apilevel-N class MUST BE LAST in the sequence of class names ?>
<div class="api apilevel-<?cs var:field.since ?>">
    <h3 class="api-name"><?cs var:field.name ?></h3>
    <div class="api-level">
      <?cs call:since_tags(field) ?>
      <?cs call:federated_refs(field) ?>
    </div>
<pre class="api-signature no-pretty-print">
<?cs if:subcount(field.scope) ?><?cs var:field.scope
?> <?cs /if ?><?cs if:subcount(field.static) ?><?cs var:field.static
?> <?cs /if ?><?cs if:subcount(field.final) ?><?cs var:field.final
?> <?cs /if ?><?cs if:subcount(field.type) ?><?cs call:type_link(field.type)
?> <?cs /if ?><?cs var:field.name ?></pre>
    <?cs call:show_annotations_list(field) ?>
    <?cs call:description(field) ?>
    <?cs if:subcount(field.constantValue) ?>
      <p>Constant Value:
      <?cs if:field.constantValue.isString ?>
          <?cs var:field.constantValue.str ?>
      <?cs else ?>
          <?cs var:field.constantValue.dec ?>
          (<?cs var:field.constantValue.hex ?>)
      <?cs /if ?>
    <?cs /if ?>
</div>
<?cs /each ?>
<?cs /def ?>

<?cs def:write_method_details(methods) ?>
<?cs each:method=methods ?>
<?cs # the A tag in the next line must remain where it is, so that Eclipse can parse the docs ?>
<A NAME="<?cs var:method.anchor ?>"></A>
<?cs # The apilevel-N class MUST BE LAST in the sequence of class names ?>
<div class="api apilevel-<?cs var:method.since ?>">
    <h3 class="api-name"><?cs var:method.name ?></h3>
    <div class="api-level">
      <div><?cs call:since_tags(method) ?></div>
      <?cs call:federated_refs(method) ?>
    </div>
<pre class="api-signature no-pretty-print">
<?cs if:subcount(method.scope) ?><?cs var:method.scope
?> <?cs /if ?><?cs if:subcount(method.static) ?><?cs var:method.static
?> <?cs /if ?><?cs if:subcount(method.final) ?><?cs var:method.final
?> <?cs /if ?><?cs if:subcount(method.abstract) ?><?cs var:method.abstract
?> <?cs /if ?><?cs if:subcount(method.returnType) ?><?cs call:type_link(method.returnType)
?> <?cs /if ?><?cs var:method.name ?> (<?cs call:parameter_list(method.params, 1) ?>)</pre>
    <?cs call:show_annotations_list(method) ?>
    <?cs call:description(method) ?>
</div>
<?cs /each ?>
<?cs /def ?>

<?cs def:write_attr_details(attrs) ?>
<?cs each:attr=attrs ?>
<?cs # the A tag in the next line must remain where it is, so that Eclipse can parse the docs ?>
<A NAME="<?cs var:attr.anchor ?>"></A>
<h3 class="api-name"><?cs var:attr.name ?></h3>
<?cs call:show_annotations_list(attr) ?>
<?cs call:description(attr) ?>
<?cs if:subcount(attr.methods) ?>
  <p><b>Related methods:</b></p>
  <ul class="nolist">
  <?cs each:m=attr.methods ?>
    <li><a href="<?cs var:toroot ?><?cs var:m.href ?>"><?cs var:m.name ?></a></li>
  <?cs /each ?>
  </ul>
<?cs /if ?>
<?cs /each ?>
<?cs /def ?>
<?cs
#########################
# END OF MACROS
# START OF PAGE PRINTING
#########################
?>
<?cs include:"doctype.cs" ?>
<html<?cs if:devsite ?> devsite<?cs /if ?>>
<?cs include:"head_tag.cs" ?>
<?cs include:"body_tag.cs" ?>
<?cs include:"header.cs" ?>
<?cs include:"page_info.cs" ?>
<?cs # This DIV spans the entire document to provide scope for some scripts ?>
<div class="api apilevel-<?cs var:class.since ?>" id="jd-content">
<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<!-- ======== START OF CLASS DATA ======== -->
<?cs
#
# Page header with class name and signature
#
?>
<h1 class="api-title"><?cs var:class.name ?></h1>
<p>
<code class="api-signature">
  <?cs var:class.scope ?>
  <?cs var:class.static ?>
  <?cs var:class.final ?>
  <?cs var:class.abstract ?>
  <?cs var:class.kind ?>
  <?cs var:class.name ?>
</code>
<br>
<?cs set:colspan = subcount(class.inheritance) ?>
<?cs each:supr = class.inheritance ?>
<code class="api-signature">
  <?cs if:colspan == 2 ?>
    extends <?cs call:type_link(supr.short_class) ?>
  <?cs /if ?>
  <?cs if:last(supr) && subcount(supr.interfaces) ?>
      implements
      <?cs each:t=supr.interfaces ?>
        <?cs call:type_link(t) ?><?cs
          if: name(t)!=subcount(supr.interfaces)-1
            ?>, <?cs /if ?>
      <?cs /each ?>
  <?cs /if ?>
  <?cs set:colspan = colspan-1 ?>
</code>
<?cs /each ?>
</p><?cs
#
# Class inheritance tree
#
?><table class="jd-inheritance-table">
<?cs set:colspan = subcount(class.inheritance) ?>
<?cs each:supr = class.inheritance ?>
  <tr>
    <?cs loop:i = 1, (subcount(class.inheritance)-colspan), 1 ?>
      <td class="jd-inheritance-space">&nbsp;<?cs
        if:(subcount(class.inheritance)-colspan) == i
          ?>&nbsp;&nbsp;&#x21b3;<?cs
        /if ?></td>
    <?cs /loop ?>
    <td colspan="<?cs var:colspan ?>" class="jd-inheritance-class-cell"><?cs
      if:colspan == 1
          ?><?cs call:class_name(class.qualifiedType) ?><?cs
      else
          ?><?cs call:type_link(supr.class) ?><?cs
      /if ?>
    </td>
  </tr>
  <?cs set:colspan = colspan-1 ?>
<?cs /each ?>
</table><?cs
#
# Collapsible list of subclasses
#
?><?cs
if:subcount(class.subclasses.direct) && !class.subclasses.hidden ?>
  <table class="jd-sumtable jd-sumtable-subclasses">
  <tr><td style="border:none;margin:0;padding:0;">
    <?cs call:expando_trigger("subclasses-direct", "closed") ?>Known Direct Subclasses
    <?cs call:expandable_class_list("subclasses-direct", class.subclasses.direct, "list") ?>
  </td></tr>
  </table>
  <?cs /if ?>
  <?cs if:subcount(class.subclasses.indirect) && !class.subclasses.hidden ?>
  <table class="jd-sumtable jd-sumtable-subclasses"><tr><td colspan="2" style="border:none;margin:0;padding:0;">
  <?cs call:expando_trigger("subclasses-indirect", "closed") ?>Known Indirect Subclasses
  <?cs call:expandable_class_list("subclasses-indirect", class.subclasses.indirect, "list") ?>
  </td></tr></table><?cs
/if ?>
<?cs call:show_annotations_list(class) ?>
<br><hr><?cs
#
# The long-form class description.
#
?><?cs call:deprecated_warning(class) ?>

<?cs if:subcount(class.descr) ?>
  <p><?cs call:tag_list(class.descr) ?></p>
<?cs /if ?>

<?cs call:see_also_tags(class.seeAlso) ?>
<?cs
#################
# CLASS SUMMARY
#################
?>
<?cs # make sure there is a summary view to display ?>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
<?cs if:subcount(class.inners)
     || subcount(class.attrs)
     || inhattrs
     || subcount(class.enumConstants)
     || subcount(class.constants)
     || inhconstants
     || subcount(class.fields)
     || inhfields
     || subcount(class.ctors.public)
     || subcount(class.ctors.protected)
     || subcount(class.methods.public)
     || subcount(class.methods.protected)
     || inhmethods ?>
<<<<<<< HEAD
<h2>Summary</h2>
=======
<h2 class="api-section">Summary</h2>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143

<?cs if:subcount(class.inners) ?>
<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<!-- ======== NESTED CLASS SUMMARY ======== -->
<<<<<<< HEAD
<table id="nestedclasses" class="jd-sumtable"><tr><th colspan="12">Nested Classes</th></tr>
=======
<table id="nestedclasses" class="responsive">
<tr><th colspan="2"><h3>Nested classes</h3></th></tr>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
<?cs call:write_inners_summary(class.inners) ?>
<?cs /if ?>

<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<?cs if:subcount(class.attrs) ?>
<!-- =========== FIELD SUMMARY =========== -->
<<<<<<< HEAD
<table id="lattrs" class="jd-sumtable"><tr><th colspan="12">XML Attributes</th></tr>
=======
<table id="lattrs" class="responsive">
<tr><th colspan="2"><h3>XML attributes</h3></th></tr>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
<?cs call:write_attr_summary(class.attrs, 1) ?>
<?cs /if ?>

<?cs # if there are inherited attrs, write the table ?>
<?cs if:inhattrs ?>
<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<!-- =========== FIELD SUMMARY =========== -->
<<<<<<< HEAD
<table id="inhattrs" class="jd-sumtable"><tr><th>
  <a href="#" class="toggle-all" onclick="return toggleAllInherited(this, null)">[Expand]</a>
  <div style="clear:left;">Inherited XML Attributes</div></th></tr>
<?cs each:cl=class.inherited ?>
<?cs if:subcount(cl.attrs) ?>
<tr class="api apilevel-<?cs var:cl.since ?>" >
<td colspan="12">
<?cs call:expando_trigger("inherited-attrs-"+cl.qualified, "closed") ?>From <?cs var:cl.kind ?>
<?cs call:cond_link(cl.qualified, toroot, cl.link, cl.included) ?>
=======
<table id="inhattrs" class="responsive inhtable">
<tr><th><h3>Inherited XML attributes</h3></th></tr>
<?cs each:cl=class.inherited ?>
<?cs if:subcount(cl.attrs) ?>
<tr class="api apilevel-<?cs var:cl.since ?>" >
<td colspan="2">
<?cs call:expando_trigger("inherited-attrs-"+cl.qualified, "closed") ?>From
<?cs var:cl.kind ?>
<code>
  <?cs call:cond_link(cl.qualified, toroot, cl.link, cl.included) ?>
</code>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
<div id="inherited-attrs-<?cs var:cl.qualified ?>">
  <div id="inherited-attrs-<?cs var:cl.qualified ?>-list"
        class="jd-inheritedlinks">
  </div>
  <div id="inherited-attrs-<?cs var:cl.qualified ?>-summary" style="display: none;">
    <table class="jd-sumtable-expando">
    <?cs call:write_attr_summary(cl.attrs, cl.included) ?></table>
  </div>
</div>
</td></tr>
<?cs /if ?>
<?cs /each ?>
</table>
<?cs /if ?>

<?cs if:subcount(class.enumConstants) ?>
<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<!-- =========== ENUM CONSTANT SUMMARY =========== -->
<<<<<<< HEAD
<table id="enumconstants" class="jd-sumtable"><tr><th colspan="12">Enum Values</th></tr>
<?cs set:count = #1 ?>
    <?cs each:field=class.enumConstants ?>
    <tr class="<?cs if:count % #2 ?>alt-color<?cs /if ?> api apilevel-<?cs var:field.since ?>" >
        <td class="jd-descrcol"><?cs call:type_link(field.type) ?>&nbsp;</td>
        <td class="jd-linkcol"><?cs call:cond_link(field.name, toroot, field.href, cl.included) ?>&nbsp;</td>
        <td class="jd-descrcol" width="100%">
          <?cs call:short_descr(field) ?>&nbsp;
          <?cs call:show_annotations_list(field) ?>
        </td>
    </tr>
    <?cs set:count = count + #1 ?>
    <?cs /each ?>
=======
<table id="enumconstants" class="responsive constants">
  <tr><th colspan="2"><h3>Enum values</h3></th></tr>
<?cs set:count = #1 ?>
  <?cs each:field=class.enumConstants ?>
  <tr class="api apilevel-<?cs var:field.since ?>" >
    <td><code><?cs call:type_link(field.type) ?></code>&nbsp;</td>
    <td width="100%">
      <code><?cs call:cond_link(field.name, toroot, field.href, cl.included) ?></code>
      <p><?cs call:short_descr(field) ?>&nbsp;
      <?cs call:show_annotations_list(field) ?></p>
    </td>
  </tr>
  <?cs set:count = count + #1 ?>
  <?cs /each ?>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
<?cs /if ?>

<?cs if:subcount(class.constants) ?>
<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<!-- =========== ENUM CONSTANT SUMMARY =========== -->
<<<<<<< HEAD
<table id="constants" class="jd-sumtable"><tr><th colspan="12">Constants</th></tr>
=======
<table id="constants" class="responsive constants">
<tr><th colspan="2"><h3>Constants</h3></th></tr>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
<?cs call:write_constant_summary(class.constants, 1) ?>
</table>
<?cs /if ?>

<?cs # if there are inherited constants, write the table ?>
<?cs if:inhconstants ?>
<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<!-- =========== ENUM CONSTANT SUMMARY =========== -->
<<<<<<< HEAD
<table id="inhconstants" class="jd-sumtable"><tr><th>
  <a href="#" class="toggle-all" onclick="return toggleAllInherited(this, null)">[Expand]</a>
  <div style="clear:left;">Inherited Constants</div></th></tr>
<?cs each:cl=class.inherited ?>
<?cs if:subcount(cl.constants) ?>
<tr class="api apilevel-<?cs var:cl.since ?>" >
<td colspan="12">
<?cs call:expando_trigger("inherited-constants-"+cl.qualified, "closed") ?>From <?cs var:cl.kind ?>
<?cs call:cond_link(cl.qualified, toroot, cl.link, cl.included) ?>
<div id="inherited-constants-<?cs var:cl.qualified ?>">
  <div id="inherited-constants-<?cs var:cl.qualified ?>-list"
        class="jd-inheritedlinks">
  </div>
  <div id="inherited-constants-<?cs var:cl.qualified ?>-summary" style="display: none;">
    <table class="jd-sumtable-expando">
    <?cs call:write_constant_summary(cl.constants, cl.included) ?></table>
  </div>
</div>
</td></tr>
=======
<table id="inhconstants" class="responsive constants inhtable">
<tr><th><h3>Inherited constants</h3></th></tr>
<?cs each:cl=class.inherited ?>
<?cs if:subcount(cl.constants) ?>
  <tr class="api apilevel-<?cs var:cl.since ?>" >
  <td>
  <?cs call:expando_trigger("inherited-constants-"+cl.qualified, "closed") ?>From
  <?cs var:cl.kind ?>
  <code>
    <?cs call:cond_link(cl.qualified, toroot, cl.link, cl.included) ?>
  </code>
  <div id="inherited-constants-<?cs var:cl.qualified ?>">
    <div id="inherited-constants-<?cs var:cl.qualified ?>-list"
          class="jd-inheritedlinks">
    </div>
    <div id="inherited-constants-<?cs var:cl.qualified ?>-summary" style="display: none;">
      <table class="jd-sumtable-expando responsive">
      <?cs call:write_constant_summary(cl.constants, cl.included) ?></table>
    </div>
  </div>
  </td></tr>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
<?cs /if ?>
<?cs /each ?>
</table>
<?cs /if ?>

<?cs if:subcount(class.fields) ?>
<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<!-- =========== FIELD SUMMARY =========== -->
<<<<<<< HEAD
<table id="lfields" class="jd-sumtable"><tr><th colspan="12">Fields</th></tr>
=======
<table id="lfields" class="responsive properties">
<tr><th colspan="2"><h3>Fields</h3></th></tr>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
<?cs call:write_field_summary(class.fields, 1) ?>
</table>
<?cs /if ?>

<?cs # if there are inherited fields, write the table ?>
<?cs if:inhfields ?>
<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<!-- =========== FIELD SUMMARY =========== -->
<<<<<<< HEAD
<table id="inhfields" class="jd-sumtable"><tr><th>
  <a href="#" class="toggle-all" onclick="return toggleAllInherited(this, null)">[Expand]</a>
  <div style="clear:left;">Inherited Fields</div></th></tr>
<?cs each:cl=class.inherited ?>
<?cs if:subcount(cl.fields) ?>
<tr class="api apilevel-<?cs var:cl.since ?>" >
<td colspan="12">
<?cs call:expando_trigger("inherited-fields-"+cl.qualified, "closed") ?>From <?cs var:cl.kind ?>
<?cs call:cond_link(cl.qualified, toroot, cl.link, cl.included) ?>
<div id="inherited-fields-<?cs var:cl.qualified ?>">
  <div id="inherited-fields-<?cs var:cl.qualified ?>-list"
        class="jd-inheritedlinks">
  </div>
  <div id="inherited-fields-<?cs var:cl.qualified ?>-summary" style="display: none;">
    <table class="jd-sumtable-expando">
    <?cs call:write_field_summary(cl.fields, cl.included) ?></table>
  </div>
</div>
</td></tr>
=======
<table id="inhfields" class="properties inhtable">
<tr><th><h3>Inherited fields</h3></th></tr>
<?cs each:cl=class.inherited ?>
<?cs if:subcount(cl.fields) ?>
  <tr class="api apilevel-<?cs var:cl.since ?>" >
  <td>
  <?cs call:expando_trigger("inherited-fields-"+cl.qualified, "closed") ?>From
  <?cs var:cl.kind ?>
  <code>
    <?cs call:cond_link(cl.qualified, toroot, cl.link, cl.included) ?>
  </code>
  <div id="inherited-fields-<?cs var:cl.qualified ?>">
    <div id="inherited-fields-<?cs var:cl.qualified ?>-list"
          class="jd-inheritedlinks">
    </div>
    <div id="inherited-fields-<?cs var:cl.qualified ?>-summary" style="display: none;">
      <table class="jd-sumtable-expando responsive">
      <?cs call:write_field_summary(cl.fields, cl.included) ?></table>
    </div>
  </div>
  </td></tr>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
<?cs /if ?>
<?cs /each ?>
</table>
<?cs /if ?>

<?cs if:subcount(class.ctors.public) ?>
<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<!-- ======== CONSTRUCTOR SUMMARY ======== -->
<<<<<<< HEAD
<table id="pubctors" class="jd-sumtable"><tr><th colspan="12">Public Constructors</th></tr>
=======
<table id="pubctors" class="responsive constructors">
<tr><th colspan="2"><h3>Public constructors</h3></th></tr>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
<?cs call:write_method_summary(class.ctors.public, 1) ?>
</table>
<?cs /if ?>

<?cs if:subcount(class.ctors.protected) ?>
<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<!-- ======== CONSTRUCTOR SUMMARY ======== -->
<<<<<<< HEAD
<table id="proctors" class="jd-sumtable"><tr><th colspan="12">Protected Constructors</th></tr>
=======
<table id="proctors" class="responsive constructors">
<tr><th colspan="2"><h3>Protected constructors</h3></th></tr>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
<?cs call:write_method_summary(class.ctors.protected, 1) ?>
</table>
<?cs /if ?>

<?cs if:subcount(class.methods.public) ?>
<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<!-- ========== METHOD SUMMARY =========== -->
<<<<<<< HEAD
<table id="pubmethods" class="jd-sumtable"><tr><th colspan="12">Public Methods</th></tr>
=======
<table id="pubmethods" class="responsive methods">
<tr><th colspan="2"><h3>Public methods</h3></th></tr>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
<?cs call:write_method_summary(class.methods.public, 1) ?>
</table>
<?cs /if ?>

<?cs if:subcount(class.methods.protected) ?>
<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<!-- ========== METHOD SUMMARY =========== -->
<<<<<<< HEAD
<table id="promethods" class="jd-sumtable"><tr><th colspan="12">Protected Methods</th></tr>
=======
<table id="promethods" class="reponsive methods">
<tr><th colspan="2"><h3>Protected methods</h3></th></tr>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
<?cs call:write_method_summary(class.methods.protected, 1) ?>
</table>
<?cs /if ?>

<?cs # if there are inherited methods, write the table ?>
<?cs if:inhmethods ?>
<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<!-- ========== METHOD SUMMARY =========== -->
<<<<<<< HEAD
<table id="inhmethods" class="jd-sumtable"><tr><th>
  <a href="#" class="toggle-all" onclick="return toggleAllInherited(this, null)">[Expand]</a>
  <div style="clear:left;">Inherited Methods</div></th></tr>
<?cs each:cl=class.inherited ?>
<?cs if:subcount(cl.methods) ?>
<tr class="api apilevel-<?cs var:cl.since ?>" >
<td colspan="12"><?cs call:expando_trigger("inherited-methods-"+cl.qualified, "closed") ?>
From <?cs var:cl.kind ?>
<?cs if:cl.included ?>
  <a href="<?cs var:toroot ?><?cs var:cl.link ?>"><?cs var:cl.qualified ?></a>
<?cs elif:cl.federated ?>
  <a href="<?cs var:cl.link ?>"><?cs var:cl.qualified ?></a>
<?cs else ?>
  <?cs var:cl.qualified ?>
<?cs /if ?>
=======
<table id="inhmethods" class="methods inhtable">
<tr><th><h3>Inherited methods</h3></th></tr>
<?cs each:cl=class.inherited ?>
<?cs if:subcount(cl.methods) ?>
<tr class="api apilevel-<?cs var:cl.since ?>" >
<td colspan="2">
<?cs call:expando_trigger("inherited-methods-"+cl.qualified, "closed") ?>From
<?cs var:cl.kind ?>
<code>
  <?cs if:cl.included ?>
    <a href="<?cs var:toroot ?><?cs var:cl.link ?>"><?cs var:cl.qualified ?></a>
  <?cs elif:cl.federated ?>
    <a href="<?cs var:cl.link ?>"><?cs var:cl.qualified ?></a>
  <?cs else ?>
    <?cs var:cl.qualified ?>
  <?cs /if ?>
</code>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
<div id="inherited-methods-<?cs var:cl.qualified ?>">
  <div id="inherited-methods-<?cs var:cl.qualified ?>-list"
        class="jd-inheritedlinks">
  </div>
  <div id="inherited-methods-<?cs var:cl.qualified ?>-summary" style="display: none;">
<<<<<<< HEAD
    <table class="jd-sumtable-expando">
    <?cs call:write_method_summary(cl.methods, cl.included) ?></table>
=======
    <table class="jd-sumtable-expando responsive">
      <?cs call:write_method_summary(cl.methods, cl.included) ?>
    </table>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
  </div>
</div>
</td></tr>
<?cs /if ?>
<?cs /each ?>
</table>
<?cs /if ?>
<?cs /if ?>
<<<<<<< HEAD
</div><!-- jd-descr (summary) -->

<!-- Details -->

<?cs def:write_field_details(fields) ?>
<?cs each:field=fields ?>
<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<?cs # the A tag in the next line must remain where it is, so that Eclipse can parse the docs ?>
<A NAME="<?cs var:field.anchor ?>"></A>
<?cs # The apilevel-N class MUST BE LAST in the sequence of class names ?>
<div class="jd-details api apilevel-<?cs var:field.since ?>"> 
    <h4 class="jd-details-title">
      <span class="normal">
        <?cs var:field.scope ?> 
        <?cs var:field.static ?> 
        <?cs var:field.final ?> 
        <?cs call:type_link(field.type) ?>
      </span>
        <?cs var:field.name ?>
    </h4>
      <div class="api-level">
        <?cs call:since_tags(field) ?>
        <?cs call:federated_refs(field) ?>
      </div>
    <div class="jd-details-descr">
      <?cs call:show_annotations_list(field) ?>
      <?cs call:description(field) ?>
    <?cs if:subcount(field.constantValue) ?>
        <div class="jd-tagdata">
        <span class="jd-tagtitle">Constant Value: </span>
        <span>
            <?cs if:field.constantValue.isString ?>
                <?cs var:field.constantValue.str ?>
            <?cs else ?>
                <?cs var:field.constantValue.dec ?>
                (<?cs var:field.constantValue.hex ?>)
            <?cs /if ?>
        </span>
        </div>
    <?cs /if ?>
    </div>
</div>
<?cs /each ?>
<?cs /def ?>

<?cs def:write_method_details(methods) ?>
<?cs each:method=methods ?>
<?cs # the A tag in the next line must remain where it is, so that Eclipse can parse the docs ?>
<A NAME="<?cs var:method.anchor ?>"></A>
<?cs # The apilevel-N class MUST BE LAST in the sequence of class names ?>
<div class="jd-details api apilevel-<?cs var:method.since ?>"> 
    <h4 class="jd-details-title">
      <span class="normal">
        <?cs var:method.scope ?> 
        <?cs var:method.static ?> 
        <?cs var:method.final ?> 
        <?cs var:method.abstract ?> 
        <?cs var:method.synchronized ?> 
        <?cs call:type_link(method.returnType) ?>
      </span>
      <span class="sympad"><?cs var:method.name ?></span>
      <span class="normal">(<?cs call:parameter_list(method.params) ?>)</span>
    </h4>
      <div class="api-level">
        <div><?cs call:since_tags(method) ?></div>
        <?cs call:federated_refs(method) ?>
      </div>
    <div class="jd-details-descr">
      <?cs call:show_annotations_list(method) ?>
      <?cs call:description(method) ?>
    </div>
</div>
<?cs /each ?>
<?cs /def ?>

<?cs def:write_attr_details(attrs) ?>
<?cs each:attr=attrs ?>
<?cs # the A tag in the next line must remain where it is, so that Eclipse can parse the docs ?>
<A NAME="<?cs var:attr.anchor ?>"></A>
<div class="jd-details"> 
    <h4 class="jd-details-title"><?cs var:attr.name ?>
    </h4>
    <div class="jd-details-descr">
        <?cs call:show_annotations_list(attr) ?>
        <?cs call:description(attr) ?>

        <div class="jd-tagdata">
            <h5 class="jd-tagtitle">Related Methods</h5>
            <ul class="nolist">
            <?cs each:m=attr.methods ?>
                <li><a href="<?cs var:toroot ?><?cs var:m.href ?>"><?cs var:m.name ?></a></li>
            <?cs /each ?>
            </ul>
        </div>
    </div>
</div>
<?cs /each ?>
<?cs /def ?>


=======
<?cs
################
# CLASS DETAILS
################
?>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
<!-- XML Attributes -->
<?cs if:subcount(class.attrs) ?>
<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<!-- ========= FIELD DETAIL ======== -->
<<<<<<< HEAD
<h2>XML Attributes</h2>
=======
<h2 class="api-section">XML attributes</h2>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
<?cs call:write_attr_details(class.attrs) ?>
<?cs /if ?>

<!-- Enum Values -->
<?cs if:subcount(class.enumConstants) ?>
<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<!-- ========= ENUM CONSTANTS DETAIL ======== -->
<<<<<<< HEAD
<h2>Enum Values</h2>
=======
<h2 class="api-section">Enum values</h2>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
<?cs call:write_field_details(class.enumConstants) ?>
<?cs /if ?>

<!-- Constants -->
<?cs if:subcount(class.constants) ?>
<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<!-- ========= ENUM CONSTANTS DETAIL ======== -->
<<<<<<< HEAD
<h2>Constants</h2>
=======
<h2 class="api-section">Constants</h2>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
<?cs call:write_field_details(class.constants) ?>
<?cs /if ?>

<!-- Fields -->
<?cs if:subcount(class.fields) ?>
<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<!-- ========= FIELD DETAIL ======== -->
<<<<<<< HEAD
<h2>Fields</h2>
=======
<h2 class="api-section">Fields</h2>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
<?cs call:write_field_details(class.fields) ?>
<?cs /if ?>

<!-- Public ctors -->
<?cs if:subcount(class.ctors.public) ?>
<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<!-- ========= CONSTRUCTOR DETAIL ======== -->
<<<<<<< HEAD
<h2>Public Constructors</h2>
=======
<h2 class="api-section">Public constructors</h2>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
<?cs call:write_method_details(class.ctors.public) ?>
<?cs /if ?>

<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<!-- ========= CONSTRUCTOR DETAIL ======== -->
<!-- Protected ctors -->
<?cs if:subcount(class.ctors.protected) ?>
<<<<<<< HEAD
<h2>Protected Constructors</h2>
=======
<h2 class="api-section">Protected constructors</h2>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
<?cs call:write_method_details(class.ctors.protected) ?>
<?cs /if ?>

<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<!-- ========= METHOD DETAIL ======== -->
<!-- Public methdos -->
<?cs if:subcount(class.methods.public) ?>
<<<<<<< HEAD
<h2>Public Methods</h2>
=======
<h2 class="api-section">Public methods</h2>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
<?cs call:write_method_details(class.methods.public) ?>
<?cs /if ?>

<?cs # this next line must be exactly like this to be parsed by eclipse ?>
<!-- ========= METHOD DETAIL ======== -->
<?cs if:subcount(class.methods.protected) ?>
<<<<<<< HEAD
<h2>Protected Methods</h2>
=======
<h2 class="api-section">Protected methods</h2>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
<?cs call:write_method_details(class.methods.protected) ?>
<?cs /if ?>

<?cs # the next two lines must be exactly like this to be parsed by eclipse ?>
<!-- ========= END OF CLASS DATA ========= -->
<<<<<<< HEAD
<A NAME="navbar_top"></A>

<?cs include:"footer.cs" ?>
</div> <!-- jd-content -->

</div><!-- end doc-content -->

<?cs include:"trailer.cs" ?>

=======

</div><!-- end jd-content -->

<?cs if:devsite ?>

<div class="data-reference-resources-wrapper">
  <?cs if:subcount(class.package) ?>
  <ul data-reference-resources>
    <?cs call:list("Annotations", class.package.annotations) ?>
    <?cs call:list("Interfaces", class.package.interfaces) ?>
    <?cs call:list("Classes", class.package.classes) ?>
    <?cs call:list("Enums", class.package.enums) ?>
    <?cs call:list("Exceptions", class.package.exceptions) ?>
    <?cs call:list("Errors", class.package.errors) ?>
  </ul>
  <?cs elif:subcount(package) ?>
  <ul data-reference-resources>
    <?cs call:class_link_list("Annotations", package.annotations) ?>
    <?cs call:class_link_list("Interfaces", package.interfaces) ?>
    <?cs call:class_link_list("Classes", package.classes) ?>
    <?cs call:class_link_list("Enums", package.enums) ?>
    <?cs call:class_link_list("Exceptions", package.exceptions) ?>
    <?cs call:class_link_list("Errors", package.errors) ?>
  </ul>
  <?cs /if ?>
</div>
<?cs /if ?>

<?cs if:!devsite ?>
<?cs include:"footer.cs" ?>
<?cs include:"trailer.cs" ?>
<?cs /if ?>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
</body>
</html>
