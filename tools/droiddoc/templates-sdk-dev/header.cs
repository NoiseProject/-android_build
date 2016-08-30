<<<<<<< HEAD
<?cs call:custom_masthead() ?>
<?cs call:custom_left_nav() ?>

=======
<?cs if:!devsite ?><?cs # leave out the global header for devsite; it is in devsite template ?>
  <?cs call:custom_masthead() ?>

  <?cs if:(fullpage) ?>
    <?cs call:fullpage() ?>
  <?cs else ?>
    <?cs call:body_content_wrap_start() ?>
  <?cs /if ?>

  <?cs call:search_results() ?>
<?cs /if ?><?cs # end if/else !devsite ?>
>>>>>>> 17e1629562b7e4d904408218673da918eb585143
