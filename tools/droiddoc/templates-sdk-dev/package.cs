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
  /if ?>">
  <div id="doc-api-level" class="<?cs var:package.since ?>" style="display:none"></div>
  <a name="top"></a>
<?cs include:"header.cs" ?>

<div class="col-12" id="doc-col">

<div id="api-info-block">
<div class="api-level">
  <?cs call:since_tags(package) ?>
  <?cs call:federated_refs(package) ?>
</div>
</div>

<div id="jd-header">
  package
  <h1><?cs var:package.name ?></h1>
</div><!-- end header -->

<div id="naMessage"></div>

<div id="jd-content" class="api apilevel-<?cs var:package.since ?>">

<?cs if:subcount(package.descr) ?>
  <div class="jd-descr">
    <?cs call:tag_list(package.descr) ?>
  </div>
=======
<?cs # THIS CREATES A PACKAGE SUMMARY PAGE FROM EACH package.html FILES
     # AND NAMES IT package-summary.html ?>
<?cs include:"macros.cs" ?>
<?cs include:"macros_override.cs" ?>
<?cs include:"doctype.cs" ?>
<html<?cs if:devsite ?> devsite<?cs /if ?>>
<?cs include:"head_tag.cs" ?>
<?cs include:"body_tag.cs" ?>
<?cs include:"header.cs" ?>
<?cs include:"page_info.cs" ?>
<div class="api apilevel-<?cs var:package.since ?>" id="jd-content">

<h1><?cs var:package.name ?></h1>

<?cs if:subcount(package.descr) ?>
  <?cs call:tag_list(package.descr) ?>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
<?cs /if ?>

<?cs def:class_table(label, classes) ?>
  <?cs if:subcount(classes) ?>
    <h2><?cs var:label ?></h2>
<<<<<<< HEAD
    <div class="jd-sumtable">
    <?cs call:class_link_table(classes) ?>
    </div>
=======
    <?cs call:class_link_table(classes) ?>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
  <?cs /if ?>
<?cs /def ?>

<?cs call:class_table("Annotations", package.annotations) ?>
<?cs call:class_table("Interfaces", package.interfaces) ?>
<?cs call:class_table("Classes", package.classes) ?>
<?cs call:class_table("Enums", package.enums) ?>
<?cs call:class_table("Exceptions", package.exceptions) ?>
<?cs call:class_table("Errors", package.errors) ?>

<<<<<<< HEAD
<?cs include:"footer.cs" ?>
</div><!-- end jd-content -->
</div><!-- doc-content -->

<?cs include:"trailer.cs" ?>

=======
</div><!-- end apilevel -->

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
