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
  <a name="top"></a>
<?cs include:"header.cs" ?>

<div class="col-12" id="doc-col">

<div id="jd-header">
<h1><?cs var:page.title ?></h1>
</div>

<div id="jd-content">
<p>These are the Android API classes. See all <a href="packages.html">API packages</a>.</p>
<div class="jd-letterlist"><?cs each:letter=docs.classes ?>
    <a href="#letter_<?cs name:letter ?>"><?cs name:letter ?></a>&nbsp;&nbsp;<?cs /each?>
=======
<?cs # THIS CREATES A LIST OF ALL PACKAGES AND NAMES IT packages.html ?>
<?cs include:"macros.cs" ?>
<?cs include:"macros_override.cs" ?>
<?cs include:"doctype.cs" ?>
<html<?cs if:devsite ?> devsite<?cs /if ?>>
<?cs include:"head_tag.cs" ?>
<?cs include:"body_tag.cs" ?>
<?cs include:"header.cs" ?>

<h1><?cs var:page.title ?></h1>
<p>These are the API classes. See all
<a href="packages.html">API packages</a>.</p>

<div class="jd-letterlist"><?cs
  each:letter=docs.classes ?>
    <a href="#letter_<?cs name:letter ?>"><?cs
      name:letter ?></a>&nbsp;&nbsp;<?cs
  /each?>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
</div>

<?cs each:letter=docs.classes ?>
<?cs set:count = #1 ?>
<h2 id="letter_<?cs name:letter ?>"><?cs name:letter ?></h2>
<<<<<<< HEAD
<table class="jd-sumtable">
=======
<table>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
    <?cs set:cur_row = #0 ?>
    <?cs each:cl = letter ?>
        <tr class="<?cs if:count % #2 ?>alt-color<?cs /if ?> api apilevel-<?cs var:cl.since ?>" >
            <td class="jd-linkcol"><?cs call:type_link(cl.type) ?></td>
            <td class="jd-descrcol" width="100%">
              <?cs call:short_descr(cl) ?>&nbsp;
              <?cs call:show_annotations_list(cl) ?>
            </td>
        </tr>
    <?cs set:count = count + #1 ?>
    <?cs /each ?>
</table>
<?cs /each ?>

<<<<<<< HEAD
<?cs include:"footer.cs" ?>
</div><!-- end jd-content -->
</div><!-- end doc-content -->

<?cs include:"trailer.cs" ?>

</body>
</html>
=======
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
</body>
</html>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
