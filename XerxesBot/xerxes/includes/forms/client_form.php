<fieldset>
    <div class="form-group">
        <label for="f_name">IMEI</label>
        <input type="text" name="imei" value="<?php echo $edit ? $client['imei'] : ''; ?>" placeholder="IMEI" class="form-control" required="required" id = "imei" >
    </div>
    <?php $number = preg_replace('/%3A/', ' ', $client['number']); ?>
    <?php $apps = preg_replace('/%0A/', ' ', $client['model']); ?>
    <!--<div class="form-group">
        <label for="l_name">Number</label>
        <input type="text" name="number" value="<?php echo $edit ? $number : ''; ?>" placeholder="Number" class="form-control" id="number">
    </div>-->

    <div class="form-group">
        <label for="version">Andriod version</label>
        <input type="text" name="version" value="<?php echo $edit ? $client['version'] : ''; ?>" placeholder="Andriod Version" class="form-control" id="version">
    </div>

    <div class="form-group">
        <label for="version_apk">Client version</label>
        <input type="text" name="version_apk" value="<?php echo $edit ? $client['version_apk'] : ''; ?>" placeholder="Client Version" class="form-control" required="required" id="version_apk">
    </div>

    <div class="form-group">
        <label for="country">Country</label>
        <input type="text" name="country" value="<?php echo $edit ? $client['country'] : ''; ?>" placeholder="Country" class="form-control" id="country">
    </div>

    <div class="form-group">
        <label for="model">Bank Apps</label>
        <input type="text" name="model" value="<?php echo $edit ? $apps : ''; ?>" placeholder="Clients bank applications" class="form-control" id="model">
    </div>

    <div class="form-group">
        <label for="model">Apps</label>
        <input type="text" name="apps" value="<?php echo $edit ? $client['apps'] : ''; ?>" placeholder="All applications from the client" class="form-control" id="apps">
    </div>

    <div class="form-group">
        <label for="comment">Comment</label>
        <input type="text" name="comment" value="<?php echo $edit ? $client['comment'] : ''; ?>" placeholder="Comment" class="form-control" id="comment">
    </div>

    <div class="form-group text-center">
        <label></label>
        <button type="submit" class="btn btn-warning" >Save <span class="glyphicon glyphicon-send"></span></button>
    </div>
</fieldset>