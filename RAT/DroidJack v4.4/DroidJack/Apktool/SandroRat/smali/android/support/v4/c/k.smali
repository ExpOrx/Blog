.class final Landroid/support/v4/c/k;
.super Ljava/lang/Object;

# interfaces
.implements Ljava/util/Collection;


# instance fields
.field final synthetic a:Landroid/support/v4/c/f;


# direct methods
.method constructor <init>(Landroid/support/v4/c/f;)V
    .locals 0

    iput-object p1, p0, Landroid/support/v4/c/k;->a:Landroid/support/v4/c/f;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public add(Ljava/lang/Object;)Z
    .locals 1

    new-instance v0, Ljava/lang/UnsupportedOperationException;

    invoke-direct {v0}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw v0
.end method

.method public addAll(Ljava/util/Collection;)Z
    .locals 1

    new-instance v0, Ljava/lang/UnsupportedOperationException;

    invoke-direct {v0}, Ljava/lang/UnsupportedOperationException;-><init>()V

    throw v0
.end method

.method public clear()V
    .locals 1

    iget-object v0, p0, Landroid/support/v4/c/k;->a:Landroid/support/v4/c/f;

    invoke-virtual {v0}, Landroid/support/v4/c/f;->c()V

    return-void
.end method

.method public contains(Ljava/lang/Object;)Z
    .locals 1

    iget-object v0, p0, Landroid/support/v4/c/k;->a:Landroid/support/v4/c/f;

    invoke-virtual {v0, p1}, Landroid/support/v4/c/f;->b(Ljava/lang/Object;)I

    move-result v0

    if-ltz v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public containsAll(Ljava/util/Collection;)Z
    .locals 2

    invoke-interface {p1}, Ljava/util/Collection;->iterator()Ljava/util/Iterator;

    move-result-object v0

    :cond_0
    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_1

    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    invoke-virtual {p0, v1}, Landroid/support/v4/c/k;->contains(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_0

    const/4 v0, 0x0

    :goto_0
    return v0

    :cond_1
    const/4 v0, 0x1

    goto :goto_0
.end method

.method public isEmpty()Z
    .locals 1

    iget-object v0, p0, Landroid/support/v4/c/k;->a:Landroid/support/v4/c/f;

    invoke-virtual {v0}, Landroid/support/v4/c/f;->a()I

    move-result v0

    if-nez v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public iterator()Ljava/util/Iterator;
    .locals 3

    new-instance v0, Landroid/support/v4/c/g;

    iget-object v1, p0, Landroid/support/v4/c/k;->a:Landroid/support/v4/c/f;

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2}, Landroid/support/v4/c/g;-><init>(Landroid/support/v4/c/f;I)V

    return-object v0
.end method

.method public remove(Ljava/lang/Object;)Z
    .locals 2

    iget-object v0, p0, Landroid/support/v4/c/k;->a:Landroid/support/v4/c/f;

    invoke-virtual {v0, p1}, Landroid/support/v4/c/f;->b(Ljava/lang/Object;)I

    move-result v0

    if-ltz v0, :cond_0

    iget-object v1, p0, Landroid/support/v4/c/k;->a:Landroid/support/v4/c/f;

    invoke-virtual {v1, v0}, Landroid/support/v4/c/f;->a(I)V

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public removeAll(Ljava/util/Collection;)Z
    .locals 5

    const/4 v2, 0x1

    const/4 v0, 0x0

    iget-object v1, p0, Landroid/support/v4/c/k;->a:Landroid/support/v4/c/f;

    invoke-virtual {v1}, Landroid/support/v4/c/f;->a()I

    move-result v3

    move v1, v0

    :goto_0
    if-ge v0, v3, :cond_1

    iget-object v4, p0, Landroid/support/v4/c/k;->a:Landroid/support/v4/c/f;

    invoke-virtual {v4, v0, v2}, Landroid/support/v4/c/f;->a(II)Ljava/lang/Object;

    move-result-object v4

    invoke-interface {p1, v4}, Ljava/util/Collection;->contains(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_0

    iget-object v1, p0, Landroid/support/v4/c/k;->a:Landroid/support/v4/c/f;

    invoke-virtual {v1, v0}, Landroid/support/v4/c/f;->a(I)V

    add-int/lit8 v0, v0, -0x1

    add-int/lit8 v1, v3, -0x1

    move v3, v1

    move v1, v2

    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    return v1
.end method

.method public retainAll(Ljava/util/Collection;)Z
    .locals 5

    const/4 v2, 0x1

    const/4 v0, 0x0

    iget-object v1, p0, Landroid/support/v4/c/k;->a:Landroid/support/v4/c/f;

    invoke-virtual {v1}, Landroid/support/v4/c/f;->a()I

    move-result v3

    move v1, v0

    :goto_0
    if-ge v0, v3, :cond_1

    iget-object v4, p0, Landroid/support/v4/c/k;->a:Landroid/support/v4/c/f;

    invoke-virtual {v4, v0, v2}, Landroid/support/v4/c/f;->a(II)Ljava/lang/Object;

    move-result-object v4

    invoke-interface {p1, v4}, Ljava/util/Collection;->contains(Ljava/lang/Object;)Z

    move-result v4

    if-nez v4, :cond_0

    iget-object v1, p0, Landroid/support/v4/c/k;->a:Landroid/support/v4/c/f;

    invoke-virtual {v1, v0}, Landroid/support/v4/c/f;->a(I)V

    add-int/lit8 v0, v0, -0x1

    add-int/lit8 v1, v3, -0x1

    move v3, v1

    move v1, v2

    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    return v1
.end method

.method public size()I
    .locals 1

    iget-object v0, p0, Landroid/support/v4/c/k;->a:Landroid/support/v4/c/f;

    invoke-virtual {v0}, Landroid/support/v4/c/f;->a()I

    move-result v0

    return v0
.end method

.method public toArray()[Ljava/lang/Object;
    .locals 2

    iget-object v0, p0, Landroid/support/v4/c/k;->a:Landroid/support/v4/c/f;

    const/4 v1, 0x1

    invoke-virtual {v0, v1}, Landroid/support/v4/c/f;->b(I)[Ljava/lang/Object;

    move-result-object v0

    return-object v0
.end method

.method public toArray([Ljava/lang/Object;)[Ljava/lang/Object;
    .locals 2

    iget-object v0, p0, Landroid/support/v4/c/k;->a:Landroid/support/v4/c/f;

    const/4 v1, 0x1

    invoke-virtual {v0, p1, v1}, Landroid/support/v4/c/f;->a([Ljava/lang/Object;I)[Ljava/lang/Object;

    move-result-object v0

    return-object v0
.end method
