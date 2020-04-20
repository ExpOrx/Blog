<fieldset>
    <div class="form-group">
        <label for="s_ip">IP</label>
        <input type="text" name="s_ip" value="<?php echo $edit ? $server['ip'] : ''; ?>" class="form-control" required="required" id="s_ip" >
    </div>
    <div class="form-group">
        <label for="s_user">User</label>
        <input type="text" name="s_user" value="<?php echo $edit ? $server['user'] : ''; ?>" class="form-control" id="s_user">
    </div>
    <div class="form-group">
        <label for="s_pass">Pass</label>
        <input type="text" name="s_pass" value="<?php echo $edit ? $server['pass'] : ''; ?>" class="form-control" id="s_pass">
    </div>

    <div class="form-group">
        <label for="s_fwd_user">Forward user</label>
        <input type="text" name="s_fwd_user" value="<?php echo $edit ? $server['forward_user'] : ''; ?>" class="form-control" id="s_fwd_user">
    </div>
    <div class="form-group">
        <label for="s_fwd_pass">Forward pass</label>
        <input type="text" name="s_fwd_pass" value="<?php echo $edit ? $server['forward_pass'] : ''; ?>" class="form-control" id="s_fwd_pass">
    </div>
    <div class="form-group">
        <label for="s_country">Country</label>
        <input type="text" name="s_country" value="<?php echo $edit ? $server['country'] : ''; ?>" class="form-control" id="s_country">
    </div>
    <div class="form-group">
        <label for="s_note">Note</label>
        <input type="text" name="s_note" value="<?php echo $edit ? $server['note'] : ''; ?>" class="form-control" id="s_note">
    </div>

    <div class="form-group text-center">
        <label></label>
        <button type="submit" class="btn btn-warning" >Save <span class="glyphicon glyphicon-send"></span></button>
    </div>
</fieldset>